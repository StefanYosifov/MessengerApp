namespace MessengerApp.ViewModels.Authentication;

using System.ComponentModel.DataAnnotations;

public class LoginResponseModel
{
    [Required] public string Token { get; init; } = null!;

    [Required] public string UserId { get; init; } = null!;

}