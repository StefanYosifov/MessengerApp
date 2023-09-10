namespace MessengerApp.Core.Services.Conversations
{
    using Common.Utilities.UserService;

    using Data.DbContext;
    using Data.Models;

    public class ConversationService : IConversationService
    {
        private readonly MessengerDbContext context;
        private readonly IUserService userService;

        public ConversationService(
            MessengerDbContext context,
            IUserService userService)
        {
            this.context = context;
            this.userService = userService;
        }

        public async Task<bool> CreateConversationUponAddingFriend(string friendId)
        {
            var currentUser = await userService.GetUser(null);
            var friend = await userService.GetUser(friendId);


            var addUsersToCollection = new List<UserConversation>()
            {
                new UserConversation()
                {
                    UserId = currentUser.Id
                },

                new UserConversation()
                {
                    UserId = friendId
                }
            };

            await context.UserConversations.AddRangeAsync(addUsersToCollection);

            var newConversation = new Conversation
            {
                Messages = new List<Message>(),
                UserConversations = addUsersToCollection
            };

            foreach (var user in addUsersToCollection)
            {
                user.ConversationId = newConversation.Id;
            }

            await context.AddAsync(newConversation);
            await context.SaveChangesAsync();
            return true;
        }
    }
}
