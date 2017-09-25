using BankSystem.Data;
using BankSystem.Models;
using System.Linq;

namespace BankSystem.Client.Core.Commands
{
    public class AddInterestCommand : Command
    {
        public AddInterestCommand(BankSystemContext db, string[] arguments) : base(db, arguments)
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

            if (this.arguments.Length != 1)
            {
                result = ErrorMessages.InvalidArgumentsCount;

                return result;
            }

            string accountNumber = arguments[0];

            if (db.SavingAccounts.Any(a => a.AccountNumber == accountNumber))
            {
                SavingAccount account = db.SavingAccounts.First(a => a.AccountNumber == accountNumber);

                account.AddInterest();

                db.SaveChanges();

                result = string.Format(SuccessMessages.Addinterest, new object[] { accountNumber, account.Balance });
            }
            else
            {
                result = string.Format(ErrorMessages.AccountDoesNotExist, accountNumber);
            }

            return result;
        }
    }
}