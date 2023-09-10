namespace MessengerApp.Core.Services.Conversations
{
    public interface IConversationService
    {

        Task<bool> CreateConversationUponAddingFriend(string friendId);

    }
}
