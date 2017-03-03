using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalDB.Models
{
    public class Diagnose
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "A diagnose name is required!")]
        public string Name { get; set; }

        public string Comments { get; set; }
    }
}
