using System;
using System.ComponentModel.DataAnnotations;
using System.Text.RegularExpressions;

namespace SocialNetwork.Models.Attributes
{
    [Obsolete]
    public class TagAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            string pattern = @"^#([a-zA-Z0-9]{1,19})$";

            string input = value as string;

            Regex rgx = new Regex(pattern);

            if (rgx.IsMatch(input))
            {
                return true;
            }
            else
            {
                return false;
            }
        }
    }
}