using BankSystem.Client.Core.Utils;
using BankSystem.Data;
using BankSystem.Models;
using System.Linq;

namespace BankSystem.Client.Core.Commands
{
    public class AddSavingsAccountCommand : Command
    {
        public AddSavingsAccountCommand(BankSystemContext db, string[] arguments) : base(db, arguments)
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

            decimal balance = decimal.Parse(arguments[0]);
            double rate = double.Parse(arguments[1]);

            string accountNumber = string.Empty;

            do
            {
                accountNumber = RandomStringGenerator.GenerateString(10);
            }
            while (
            db.SavingAccounts.Any(sa => sa.AccountNumber == accountNumber)
            ||
            db.CheckingAccounts.Any(ca => ca.AccountNumber == accountNumber)
            );

            var account = new SavingAccount(accountNumber, balance, Engine.CurrentUserId, rate);

            db.SavingAccounts.Add(account);
            db.SaveChanges();

            result = string.Format(SuccessMessages.AccountAdded, accountNumber);

            return result;
        }
    }
}