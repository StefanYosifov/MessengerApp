namespace MessengerApp.ViewModels.Authentication
{
    using System.ComponentModel.DataAnnotations;

    using MessengerApp.Infrastructure.Constants.Constants;

    public class LoginViewModel
    {

        [Required]
        [StringLength(AuthenticationConstants.UserNameMaxLength,MinimumLength = AuthenticationConstants.UserNameMinLength)]
        public string UserName { get; set; } = null!;

        [Required]
        [StringLength(AuthenticationConstants.PasswordMaxLength,MinimumLength = AuthenticationConstants.PasswordMinLength)]
        public string Password { get; set; } = null!;

    }
}