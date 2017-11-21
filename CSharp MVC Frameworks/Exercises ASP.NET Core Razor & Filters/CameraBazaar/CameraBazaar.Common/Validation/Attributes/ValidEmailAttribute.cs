using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CameraBazaar.Common.Validation.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class ValidEmailAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            string email = value as string;

            if (email is null)
            {
                return false;
            }

            string emailPattern = @"^([a-zA-Z0-9]+[.-_]?[a-zA-Z0-9]+)(@)[a-zA-Z0-9]+(\.[a-zA-Z0-9]{2,})+$";

            Regex rgx = new Regex(emailPattern);

            return rgx.IsMatch(email);
        }
    }
}