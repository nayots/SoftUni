using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalDB.Models
{
    public class Visitation
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Visitation Date must be specified")]
        public DateTime Date { get; set; }

        public string Comments { get; set; }

        [Required(ErrorMessage ="Each visitation entry requires a doctor!")]
        public Doctor Doctor { get; set; }
    }
}
