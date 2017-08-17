using _05.Security_Door.Models.Contracts;

namespace _05.Security_Door
{
    public abstract class SecurityCheck : IValidate
    {
        public abstract bool ValidateUser();
    }
}