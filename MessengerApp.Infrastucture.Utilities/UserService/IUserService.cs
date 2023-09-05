namespace MessengerApp.Common.Utilities.UserService
{
    using Data.Models;

    public interface IUserService
    {


        string GetUserId();
        string GetUserName();

        Task<ApplicationUser> ReturnUser();
    }
}
