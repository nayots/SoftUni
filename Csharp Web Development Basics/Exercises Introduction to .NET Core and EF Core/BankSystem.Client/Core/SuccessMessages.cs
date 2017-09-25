namespace BankSystem.Client.Core
{
    public static class SuccessMessages
    {
        public const string UserRegistered = @"User {0} was registered in the system.";
        public const string UserLoggedIn = @"Succesfully logged in {0}.";
        public const string UserLoggedOut = @"User {0} successfully logged out";
        public const string AccountAdded = @"Succesfully added account with number {0}";
        public const string DepositAndWithdrawSuccess = @"Account {0} has balance of {1:F2}";
        public const string DeductFee = @"Deducted fee of {0}. Current balance: {1:F2}";
        public const string Addinterest = @"Added interest to {0}. Current balance: {1:F2}";
    }
}