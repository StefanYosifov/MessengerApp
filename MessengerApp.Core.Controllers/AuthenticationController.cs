namespace MessengerApp.Core.Controllers
{
    using Data.DbContext;
    using Data.Models;
    using Infrastcuture.Exceptions;
    using Microsoft.AspNetCore.Authorization;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.AspNetCore.Mvc;
    using Services.Authentication;
    using ViewModels.Authentication;

    [AllowAnonymous]
    [Route("/authenticate")]
    public class AuthenticationController : ApiController
    {
        private readonly MessengerDbContext context;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly IAuthenticationService service;

        public AuthenticationController(
            MessengerDbContext context,
            UserManager<ApplicationUser> userManager,
            IAuthenticationService service)
        {
            this.context = context;
            this.userManager = userManager;
            this.service = service;
        }

        [AllowAnonymous]
        [HttpPost("login")]
        public async Task<IActionResult> Login(LoginViewModel loginModel)
        {
            try
            {
                var loginResult = await service.Login(loginModel);
                return Ok(loginResult);
            }
            catch (ServiceExceptions e)
            {
                return BadRequest(e.Message);
            }
        }

        [HttpPost("register")]
        public async Task<IActionResult> Register(RegisterViewModel registerModel)
        {
            try
            {
                var registerResult=await service.Register(registerModel);
                return Ok(registerResult);
            }
            catch (ServiceExceptions e)
            {
                return BadRequest(e.Message);
            }
        }
    }
}