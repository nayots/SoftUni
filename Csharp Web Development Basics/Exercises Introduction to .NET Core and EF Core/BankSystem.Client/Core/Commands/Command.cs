using BankSystem.Client.Contracts;
using BankSystem.Data;

namespace BankSystem.Client.Core.Commands
{
    public abstract class Command : IExecutable
    {
        protected BankSystemContext db;
        protected string[] arguments;

        public Command(BankSystemContext db, string[] arguments)
        {
            this.db = db;
            this.arguments = arguments;
        }

        public abstract string Execute();
    }
}