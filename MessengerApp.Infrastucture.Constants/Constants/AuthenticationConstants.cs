namespace MessengerApp.Infrastructure.Constants.Constants
{
    public class AuthenticationConstants
    {

        public const int UserNameMinLength = 4;
        public const int UserNameMaxLength = 30;

        public const int PasswordMinLength = 5;
        public const int PasswordMaxLength = 40;

        public const string EmailRegex =
            "/^[a-zA-Z0-9.!#$%&'*+\\/=?^_`{|}~-]+@[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?(?:\\.[a-zA-Z0-9](?:[a-zA-Z0-9-]{0,61}[a-zA-Z0-9])?)*$/\r\n";

    }
}
