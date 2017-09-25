namespace BankSystem.Client.Core
{
    public static class ErrorMessages
    {
        public const string InvalidArgumentsCount = "Invalid Arguments Count!";
        public const string IncorrectUsername = "Incorrect username!";
        public const string IncorrectPassword = "Incorrect password!";
        public const string IncorrectEmail = "Incorrect Email!";
        public const string UserExists = "User {0} already exists!";
        public const string UserIsLogged = "You cannot {0} while logged in!";
        public const string UserIsLoggedOut = "Cannot log out. No user was logged in.";
        public const string IncorrectUsernameOrPassword = "Incorrect username / password";
        public const string AccountDoesNotExist = @"Account {0} does not exist!";
        public const string InvalidCommand = "Command {0} is not supported!\r\nType end to exit.";
        public const string ActionDenied = "You must log in first!";
    }
}