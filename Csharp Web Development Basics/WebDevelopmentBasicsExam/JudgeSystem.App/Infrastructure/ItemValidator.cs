using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace JudgeSystem.App.Infrastructure
{
    public static class ItemValidator
    {
        public static bool IsValidEmail(string email)
        {
            return email.Contains(".") && email.Contains("@");
        }

        public static bool IsValidPassword(string password)
        {
            return password.Any(s => char.IsDigit(s))
                && password.Any(s => char.IsUpper(s))
                && password.Any(s => char.IsLower(s))
                && password.Length >= 6;
        }

        internal static bool IsValidName(string fullName)
        {
            if (string.IsNullOrEmpty(fullName) || string.IsNullOrWhiteSpace(fullName))
            {
                return false;
            }

            return true;
        }
    }
}