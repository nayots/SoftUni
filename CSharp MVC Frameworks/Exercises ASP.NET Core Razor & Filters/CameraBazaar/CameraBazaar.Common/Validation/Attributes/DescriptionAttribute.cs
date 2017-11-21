using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraBazaar.Common.Validation.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class DescriptionAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            string text = value as string;

            return text != null && text.Length <= 6000;
        }
    }
}