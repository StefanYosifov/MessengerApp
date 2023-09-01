namespace MessengerApp.Core.Services.Friends
{
    using ViewModels.Friends;

    public interface IFriendService
    {

        Task<ICollection<FriendViewModel>> GetFriends();

        Task<string> SendFriendRequest();

        Task<string> AcceptFriendRequest();

        Task<ICollection<SearchFriendViewModel>> SearchUsersByName(string name);

    }
}
