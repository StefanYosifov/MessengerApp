namespace MessengerApp.Common.Utilities.UserService
{
    using System.Security.Claims;

    using Microsoft.AspNetCore.Http;

    public class UserService : IUserService
    {
        public readonly ClaimsPrincipal user;

        public UserService(IHttpContextAccessor user)
        {
            this.user = user.HttpContext!.User;
        }

        public string GetUserId()
            => user.FindFirstValue(ClaimTypes.NameIdentifier);

        public string GetUserName()
            => user.Identity!.Name!;
        
    }
}
