namespace MessengerApp.Core.Services.Friends
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    using Common.Utilities.UserService;

    using Conversations;

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
        private readonly IMapper mapper;
        private readonly IUserService userService;
        private readonly IConversationService conversationService;

        public FriendService(
            MessengerDbContext context,
            IUserService userService,
            IMapper mapper,
            IConversationService conversationService)
        {
            this.context = context;
            this.userService = userService;
            this.mapper = mapper;
            this.conversationService = conversationService;
        }

        public async Task<ICollection<FriendViewModel>> GetFriends()
        {

            var userId = userService.GetUserId();

            var friends = PrivateGetUserFriends();

            return await friends
                .Select(f => new FriendViewModel
                {
                    FriendShipId = f.Id,
                    FriendName = f.ReceiverUserId == userId ? f.Receiver.UserName : f.Sender.UserName,
                    FriendProfilePicture = f.ReceiverUserId == userId ? f.Receiver.ImageUrl : f.Sender.ImageUrl
                })
                .ToArrayAsync();
        }

        public async Task<string> SendFriendRequest(string friendUserId)
        {
            var userId = userService.GetUserId();

            var findFriendShip = await context.FriendShips
                .FirstOrDefaultAsync(f =>
                    (f.SenderId == userId && f.ReceiverUserId == friendUserId) ||
                    (f.SenderId == friendUserId && f.ReceiverUserId == userId));

            if (findFriendShip != null)
            {
                throw new ServiceExceptions(FriendMessages.AlreadySentFriendRequest);
            }

            if (findFriendShip?.Status == FriendRequestStatus.Accepted)
            {
                throw new ServiceExceptions(FriendMessages.AlreadyFriends);
            }

            var newFriendRequest = new FriendShip
            {
                SenderId = userId,
                ReceiverUserId = friendUserId,
                Status = FriendRequestStatus.Pending
            };

            context.FriendShips.Add(newFriendRequest);
            await context.SaveChangesAsync();

            return "Friend request sent successfully.";
        }

        public async Task<string> AcceptFriendRequest(RespondToFriendRequest request)
        {
            var userId = userService.GetUserId();

            var findRequest = await context.FriendShips
                .Include(f => f.Receiver)
                .Include(f => f.Sender)
                .FirstOrDefaultAsync(fr => fr.Id == request.RequestId);

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
            var isCreatingConversationSuccessful = await conversationService.CreateConversationUponAddingFriend(findRequest.SenderId);



            return string.Format(FriendMessages.SuccessfullyAcceptedFriendRequest, findRequest.Sender.UserName);
        }

        public async Task<ICollection<SearchFriendViewModel>> SearchUsersByName(string userName)
        {
            var userId = userService.GetUserId();

            // todo Maybe change to hashset for optimization later on
            var friendIds = await
                PrivateGetUserFriends()
                    .Select(x => x.ReceiverUserId == userId ? x.ReceiverUserId : x.SenderId)
                    .ToArrayAsync();

            return await context.Users
                .Where(u => u.UserName.Contains(userName) && u.Id != userId && friendIds.All(friendId => friendId != u.Id))
                .ProjectTo<SearchFriendViewModel>(mapper.ConfigurationProvider)
                .ToArrayAsync();
        }

        public async Task<ICollection<FriendRequestsViewModel>> ViewMyFriendRequests()
        {
            var userId = userService.GetUserId();

            return await context.FriendShips
                .Where(fr => fr.ReceiverUserId == userId)
                .ProjectTo<FriendRequestsViewModel>(mapper.ConfigurationProvider)
                .ToArrayAsync();
        }

        // Returns IQueryable in order to be able to map it via auto mapper
        private IQueryable<FriendShip> PrivateGetUserFriends()
        {
            var userId = userService.GetUserId();

            return context.FriendShips
                .Where(f => (f.SenderId == userId || f.ReceiverUserId == userId) &&
                            f.Status == FriendRequestStatus.Accepted);
        }
    }
}