namespace MessengerApp.Core.Services.Authentication
{
    using Constants.ExceptionMessages;
    using Data.DbContext;
    using Data.Models;
    using Infrastcuture.Exceptions;
    using Microsoft.AspNetCore.Identity;
    using Microsoft.Extensions.Configuration;
    using Microsoft.IdentityModel.Tokens;
    using System;
    using System.IdentityModel.Tokens.Jwt;
    using System.Security.Claims;
    using System.Text;
    using System.Threading.Tasks;
    using ViewModels.Authentication;

    public class AuthenticationService : IAuthenticationService
    {

        private readonly MessengerDbContext context;
        private readonly UserManager<ApplicationUser> userManager;
        private readonly SignInManager<ApplicationUser> signInManager;

        private readonly IConfiguration configuration;

        public AuthenticationService(
            MessengerDbContext context,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            IConfiguration configuration)
        {
            this.context = context;
            this.userManager = userManager;
            this.signInManager = signInManager;
            this.configuration = configuration;
        }

        public async Task<LoginResponseModel> Login(LoginViewModel loginModel)
        {

            var findUser = await userManager.FindByNameAsync(loginModel.UserName);

            if (findUser == null)
            {
                throw new ServiceExceptions(AuthenticationMessage.UserNameAlreadyExists);
            }

            var result = await signInManager.CheckPasswordSignInAsync(findUser, loginModel.Password, false);

            if (result.Succeeded == false)
            {
                throw new ServiceExceptions(AuthenticationMessage.PasswordIsNotCorrect);
            }

            var authClaims = new List<Claim>
            {
                new(ClaimTypes.Name, findUser.UserName),
                new(ClaimTypes.NameIdentifier, findUser.Id),
                new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),

            };

            var token = GetToken(authClaims);
            var response = await GetResponse(token, findUser);
            return response;
        }

        public async Task<LoginResponseModel> Register(RegisterViewModel registerModel)
        {
            var findUserByUserName = await userManager.FindByNameAsync(registerModel.UserName);

            if (findUserByUserName != null)
            {
                throw new ServiceExceptions(AuthenticationMessage.UserNameAlreadyExists);
            }

            var findUserByEmail = await userManager.FindByEmailAsync(registerModel.Email);

            if (findUserByEmail != null)
            {
                throw new ServiceExceptions(AuthenticationMessage.EmailAlreadyExists);
            }

            var createdUser = new ApplicationUser()
            {
                Email = registerModel.Email,
                UserName = registerModel.UserName,
            };

            var registrationResult = await userManager.CreateAsync(createdUser, registerModel.Password);

            if (!registrationResult.Succeeded)
            {
                throw new ServiceExceptions(AuthenticationMessage.AuthenticationError);
            }

            var authClaims = new List<Claim>
            {
                new(ClaimTypes.Name, createdUser.UserName),
                new(ClaimTypes.NameIdentifier, createdUser.Id),
                new(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString()),
            };

            var token = GetToken(authClaims);
            var response = await GetResponse(token, createdUser);
            return response;

        }


        //Keeping it Task for later due to roles 
        private Task<LoginResponseModel> GetResponse(JwtSecurityToken token, ApplicationUser user)
        {
            var response = new LoginResponseModel()
            {
                Token = new JwtSecurityTokenHandler().WriteToken(token),
                UserId = user.Id
            };

            return Task.FromResult(response);
        }


        //todo get rid of magic variables
        private JwtSecurityToken GetToken(List<Claim> authClaims)
        {
            var authSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(configuration["JWT:Secret"]));

            var token = new JwtSecurityToken(
                configuration["JWT:ValidIssuer"],
                configuration["JWT:ValidAudience"],
                expires: DateTime.Now.AddHours(72),
                claims: authClaims,
                signingCredentials: new SigningCredentials(authSigningKey, SecurityAlgorithms.HmacSha256)
            );

            return token;
        }
    }
}
