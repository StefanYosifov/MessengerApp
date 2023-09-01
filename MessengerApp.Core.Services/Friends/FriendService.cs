namespace MessengerApp.Core.Services.Friends
{
    using AutoMapper;
    using AutoMapper.QueryableExtensions;

    using Common.Utilities.UserService;

    using Data.DbContext;

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

        public Task<string> SendFriendRequest()
        {
            throw new NotImplementedException();
        }

        public Task<string> AcceptFriendRequest()
        {
            throw new NotImplementedException();
        }

        public async Task<ICollection<SearchFriendViewModel>> SearchUsersByName(string name)
        {
            var userId = userService.GetUserId();

            var searchedUsers = context.Friends.AsQueryable();

            return await searchedUsers
                .Where(u => EF.Functions.Like(name.ToLower(), name.ToLower()))
                .Take(12) //todo Change the magic number later on
                .ProjectTo<SearchFriendViewModel>(mapper.ConfigurationProvider)
                .ToArrayAsync();

        }
    }
}
