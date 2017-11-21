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
    public class ValidPasswordAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var password = value as string;

            string pattern = @"^[a-z0-9]{3,}$";

            Regex rgx = new Regex(pattern);

            return rgx.IsMatch(password);
        }
    }
}