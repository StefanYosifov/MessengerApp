namespace MessengerApp.Core.Services.Friends
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    using Common.Utilities.UserService;

    using Data.DbContext;
    using Data.Models;
    using Data.Models.Enums;

    using Infrastcuture.Exceptions;

    using Infrastucture.Constants.ExceptionMessages;

    using Microsoft.EntityFrameworkCore;

    using ViewModels.Friends;

    public class FriendService : IFriendService
    {
        private readonly MessengerDbContext context;
        private readonly IUserService userService;
        private readonly IMapper mapper;

        public FriendService(
            MessengerDbContext context,
            IUserService userService,
            IMapper mapper)
        {
            this.context = context;
            this.userService = userService;
            this.mapper = mapper;
        }

        public async Task<ICollection<FriendViewModel>> GetFriends()
        {
            var userId = userService.GetUserId();
            return await context.Users
                .Where(x => x.Friends.Any(f => f.FriendId == userId))
                .ProjectTo<FriendViewModel>(mapper.ConfigurationProvider)
                .ToArrayAsync();
        }

        public async Task<string> SendFriendRequest(string friendUserId)
        {
            var userId = userService.GetUserId();

            var areAlreadyFriends = await context.Friends
                .AnyAsync(f =>
                    (f.UserId == userId && f.FriendId == friendUserId) ||
                    (f.UserId == friendUserId && f.FriendId == userId));

            if (areAlreadyFriends)
            {
                throw new ServiceExceptions(FriendMessages.AlreadyFriends);
            }

            var friendRequestExists = await context.FriendRequests
                .AnyAsync(fr =>
                    (fr.SenderId == userId && fr.ReceiverUserId == friendUserId) ||
                    (fr.SenderId == friendUserId && fr.ReceiverUserId == userId));

            if (friendRequestExists)
            {
                throw new ServiceExceptions(FriendMessages.AlreadySentFriendRequest);
            }

            var newFriendRequest = new FriendRequest
            {
                SenderId = userId,
                ReceiverUserId = friendUserId,
                Status = FriendRequestStatus.Pending 
            };

            context.FriendRequests.Add(newFriendRequest);
            await context.SaveChangesAsync();

            return "Friend request sent successfully.";
        }

        public async Task<string> AcceptFriendRequest(int requestId)
        {
            var userId= userService.GetUserId();

            var findRequest = await context.FriendRequests.FindAsync(requestId);

            if (findRequest == null)
            {
                throw new ServiceExceptions(FriendMessages.NonExistingFriendRequest);
            }

            if (findRequest.Receiver.Id != userId)
            {
                throw new ServiceExceptions(FriendMessages.InvalidOperation);
            }

            if (findRequest.Status != FriendRequestStatus.Pending)
            {
                throw new ServiceExceptions(FriendMessages.InvalidOperation);
            }

            findRequest.Status = FriendRequestStatus.Accepted;

            await context.SaveChangesAsync();

            return
        }

        public async Task<ICollection<SearchFriendViewModel>> SearchUsersByName(string userName)
        {
            var userId = userService.GetUserId();
            var searchedUsers = context.Users.AsQueryable();
            var friends = context.Friends
                .Where(f => f.FriendId == userId || f.UserId == userId)
                .Select(f => f.FriendId == userId ? f.Friends.Id : f.UserId)
                .ToList();

            
            return await searchedUsers
                .Include(u=>u.Friends)
                .Select(x=>new
                {
                    x.UserName,
                    x.Id,
                    x.ImageUrl,
                    x.Friends
                })
                .Where(u => u.UserName.ToLower().Contains(userName.ToLower()) && u.Id!=userId && u.Friends.Any(f => friends.Any(fr => fr == f.UserId)))
                .Take(12) //todo Change the magic number later on
                .ProjectTo<SearchFriendViewModel>(mapper.ConfigurationProvider)
                .ToArrayAsync();

        }

        public async Task<ICollection<FriendRequestsViewModel>> ViewMyFriendRequests()
        {
            var userId= userService.GetUserId();

            return await context.FriendRequests
                .Where(fr => fr.ReceiverUserId == userId)
                .ProjectTo<FriendRequestsViewModel>(mapper.ConfigurationProvider)
                .ToArrayAsync();
        }
    }
}
