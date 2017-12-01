using System.ComponentModel.DataAnnotations;

namespace BookShop.Common.Validation.Attributes
{
    public class PriceAttribute : ValidationAttribute
    {
        public override bool IsValid(object value)
        {
            decimal price;

            if (!decimal.TryParse(value.ToString(), out price))
            {
                return false;
            }

            if (price < 0)
            {
                return false;
            }

            return true;
        }
    }
}