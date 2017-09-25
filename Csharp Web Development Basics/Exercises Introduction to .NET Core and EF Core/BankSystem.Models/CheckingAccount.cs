namespace BankSystem.Models
{
    public class CheckingAccount : BaseAccount
    {
        private CheckingAccount() : base()
        {
        }

        public CheckingAccount(string accountNumber, decimal balance, int userId, decimal fee) : base(accountNumber, balance, userId)
        {
            this.Fee = fee;
        }

        public decimal Fee { get; set; }

        public void DeductFee()
        {
            this.Balance -= this.Fee;
        }
    }
}