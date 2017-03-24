using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CarDealer.Models
{
    public class Sale
    {
        [Key]
        public int Id { get; set; }

        [Required]
        public virtual Car Car { get; set; }
        [Required]
        public virtual Customer Customer { get; set; }
        [Required]
        public decimal Discount { get; set; }
    }
}
