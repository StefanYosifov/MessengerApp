namespace MessengerApp.Core.Services.Friends
{
    using ViewModels.Friends;

    public interface IFriendService
    {

        Task<ICollection<FriendViewModel>> GetFriends();

        Task<string> SendFriendRequest(string friendUserId);

        Task<string> AcceptFriendRequest(int requestId);

        Task<ICollection<SearchFriendViewModel>> SearchUsersByName(string userName);

        Task<ICollection<FriendRequestsViewModel>> ViewMyFriendRequests();

    }
}
