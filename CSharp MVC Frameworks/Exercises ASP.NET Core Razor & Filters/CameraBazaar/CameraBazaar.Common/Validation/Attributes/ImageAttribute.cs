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
    public class ImageAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            var path = value as string;

            string pattern = @"^(?:http|https):\/\/.+$";

            Regex rgx = new Regex(pattern);

            return path != null && rgx.IsMatch(path);
        }
    }
}