namespace MessengerApp.Constants.ExceptionMessages
{
    public static class AuthenticationMessage
    {
        public const string UserNameAlreadyExists = "Use with such username already exist";
        public const string PasswordIsNotCorrect = "Incorrect password, please try again";

        public const string UserNameDoesNotExist = "Such username does not exist, please try again";
        public const string EmailAlreadyExists = "Such email already exist, please try again with another";
        public const string AuthenticationError = "There was an issue with the authentication, please try again";
    }
}
