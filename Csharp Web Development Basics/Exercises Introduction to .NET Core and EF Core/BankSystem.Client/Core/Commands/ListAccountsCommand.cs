using BankSystem.Data;
using System.Linq;
using System.Text;

namespace BankSystem.Client.Core.Commands
{
    public class ListAccountsCommand : Command
    {
        public ListAccountsCommand(BankSystemContext db, string[] arguments) : base(db, arguments)
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

            if (this.arguments.Length != 0)
            {
                result = ErrorMessages.InvalidArgumentsCount;

                return result;
            }

            var sb = new StringBuilder();

            var savingAccounts = db.SavingAccounts
                .Select(sa => new
                {
                    Number = sa.AccountNumber,
                    Balance = sa.Balance
                })
                .OrderBy(a => a.Number)
                .ToList();

            var checkingAccounts = db.CheckingAccounts
                .Select(sa => new
                {
                    Number = sa.AccountNumber,
                    Balance = sa.Balance
                })
                .OrderBy(a => a.Number)
                .ToList();

            sb.AppendLine("Saving Accounts:");

            if (savingAccounts.Count == 0)
            {
                sb.AppendLine("--None");
            }

            foreach (var acc in savingAccounts)
            {
                sb.AppendLine($"--{acc.Number} {acc.Balance:F2}");
            }

            sb.AppendLine("Checking Accounts:");

            if (checkingAccounts.Count == 0)
            {
                sb.AppendLine("--None");
            }

            foreach (var acc in checkingAccounts)
            {
                sb.AppendLine($"--{acc.Number} {acc.Balance:F2}");
            }

            result = sb.ToString().Trim();

            return result;
        }
    }
}