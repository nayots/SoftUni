using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingsPlanner.Models
{
    public class Cash : Present
    {
        [Required]
        public decimal CashAmount { get; set; }
    }
}
