using System;
using System.ComponentModel.DataAnnotations;

namespace CarDealerSystem.Services.Models.Customers
{
    public class CustomerEditDeleteModel
    {
        [Required]
        public int? Id { get; set; }

        [Required]
        public string Name { get; set; }

        [Required]
        [DataType(DataType.Date)]
        public DateTime? Birthday { get; set; }
    }
}