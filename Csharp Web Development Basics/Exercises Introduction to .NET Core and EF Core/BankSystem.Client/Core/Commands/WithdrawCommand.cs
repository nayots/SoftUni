using BankSystem.Data;
using BankSystem.Models;
using System;
using System.Linq;

namespace BankSystem.Client.Core.Commands
{
    public class WithdrawCommand : Command
    {
        public WithdrawCommand(BankSystemContext db, string[] arguments) : base(db, arguments)
        {
        }

        public override string Execute()
        {
            string result = string.Empty;

            if (!Engine.UserIsLogged)
            {
                result = string.Format(ErrorMessages.ActionDenied);

                return result;
            }

            if (this.arguments.Length != 2)
            {
                result = ErrorMessages.InvalidArgumentsCount;

                return result;
            }

            string accountNumber = arguments[0];
            decimal amount = decimal.Parse(arguments[1]);

            BaseAccount account = null;

            try
            {
                if (db.SavingAccounts.Any(a => a.AccountNumber == accountNumber))
                {
                    account = db.SavingAccounts.First(a => a.AccountNumber == accountNumber);

                    account.WithdrawMoney(amount);

                    result = string.Format(SuccessMessages.DepositAndWithdrawSuccess, new object[] { accountNumber, account.Balance });
                    db.SaveChanges();
                }
                else if (db.CheckingAccounts.Any(a => a.AccountNumber == accountNumber))
                {
                    account = db.CheckingAccounts.First(a => a.AccountNumber == accountNumber);

                    account.WithdrawMoney(amount);
                    db.SaveChanges();
                    result = string.Format(SuccessMessages.DepositAndWithdrawSuccess, new object[] { accountNumber, account.Balance });
                }
                else
                {
                    result = string.Format(ErrorMessages.AccountDoesNotExist, accountNumber);
                }
            }
            catch (ArgumentOutOfRangeException ex)
            {
                result = ex.Message;
            }

            return result;
        }
    }
}