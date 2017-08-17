namespace _05.Security_Door
{
    public class PinCodeCheck : SecurityCheck
    {
        private ISecurityUI securityUI;

        public PinCodeCheck(ISecurityUI securityUI)
        {
            this.securityUI = securityUI;
        }

        public bool IsValid(int pin)
        {
            return true;
        }

        public override bool ValidateUser()
        {
            int pin = securityUI.RequestPinCode();
            if (IsValid(pin))
            {
                return true;
            }

            return false;
        }
    }
}