using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace CameraBazaar.Common.Validation.Attributes
{
    public class ValidPhoneAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var phone = value as string;

            if (phone is null)
            {
                return false;
            }

            string pattern = @"^\+\d{10,12}$";

            Regex rgx = new Regex(pattern);

            return rgx.IsMatch(phone);
        }
    }
}