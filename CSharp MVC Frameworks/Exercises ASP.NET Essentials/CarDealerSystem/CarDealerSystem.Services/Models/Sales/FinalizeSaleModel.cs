using System.ComponentModel.DataAnnotations;

namespace CarDealerSystem.Services.Models.Sales
{
    public class FinalizeSaleModel
    {
        public int CustomerId { get; set; }

        public string CustomerName { get; set; }

        public int CarId { get; set; }

        public string CarName { get; set; }

        public double Discount { get; set; }

        [Display(Name = "Car Price")]
        public decimal NormalPrice { get; set; }

        [Display(Name = "Final Car Price")]
        public decimal DiscountPrice { get; set; }

        public bool IsYoungDriver { get; set; }
    }
}