using System;

namespace BankSystem.Models
{
    public abstract class BaseAccount
    {
        private const string AmountErrorMessage = "The amount must be a positive number.";

        protected BaseAccount()
        {
        }

        public BaseAccount(string accountNumber, decimal balance, int userId)
        {
            AccountNumber = accountNumber;
            Balance = balance;
            UserId = userId;
        }

        public int Id { get; set; }

        public string AccountNumber { get; set; }

        public decimal Balance { get; set; }

        public int UserId { get; set; }

        public User User { get; set; }

        public void DepositMoney(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(AmountErrorMessage);
            }

            this.Balance += amount;
        }

        public void WithdrawMoney(decimal amount)
        {
            if (amount <= 0)
            {
                throw new ArgumentOutOfRangeException(AmountErrorMessage);
            }

            this.Balance -= amount;
        }
    }
}