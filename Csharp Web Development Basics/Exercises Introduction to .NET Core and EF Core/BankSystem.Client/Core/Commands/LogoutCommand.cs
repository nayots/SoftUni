using BankSystem.Data;

namespace BankSystem.Client.Core.Commands
{
    public class LogoutCommand : Command
    {
        public LogoutCommand(BankSystemContext db, string[] arguments) : base(db, arguments)
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

            result = string.Format(SuccessMessages.UserLoggedOut, Engine.CurrentUserUsername);

            Engine.CurrentUserId = -1;
            Engine.UserIsLogged = false;
            Engine.CurrentUserUsername = string.Empty;

            return result;
        }
    }
}