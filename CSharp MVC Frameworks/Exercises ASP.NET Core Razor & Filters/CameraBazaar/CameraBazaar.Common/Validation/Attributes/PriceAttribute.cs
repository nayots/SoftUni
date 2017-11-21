using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CameraBazaar.Common.Validation.Attributes
{
    [AttributeUsage(AttributeTargets.Property)]
    public class PriceAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            decimal price = 0;

            if (value is null || !decimal.TryParse(value.ToString(), out price))
            {
                return false;
            }

            return price > 0m;
        }
    }
}