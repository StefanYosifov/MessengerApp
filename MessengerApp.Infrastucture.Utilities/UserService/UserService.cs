namespace MessengerApp.Common.Utilities.UserService
{
    using System.Security.Claims;

    using Data.DbContext;
    using Data.Models;

    using Microsoft.AspNetCore.Http;

    public class UserService : IUserService
    {
        private readonly ClaimsPrincipal user;
        private readonly MessengerDbContext context;

        public UserService(
            IHttpContextAccessor user, 
            MessengerDbContext context)
        {
            this.context = context;
            this.user = user.HttpContext!.User;
        }

        public string GetUserId()
            => user.FindFirstValue(ClaimTypes.NameIdentifier);

        public string GetUserName()
            => user.Identity!.Name!;

        public async Task<ApplicationUser> ReturnUser()
        {
            var userId = this.GetUserId();
            return (await context.Users.FindAsync(userId))!;
        }

    }
}
