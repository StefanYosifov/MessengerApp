namespace MessengerApp.Core.Services.Authentication
{
    using ViewModels.Authentication;

    public interface IAuthenticationService
    {

        Task<LoginResponseModel> Login(LoginViewModel loginModel);

        Task<LoginResponseModel> Register(RegisterViewModel registerModel);



    }
}
