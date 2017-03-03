using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalDB.Models
{
    public class Doctor
    {
        public Doctor()
        {
            this.Visitations = new HashSet<Visitation>();
        }

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Doctor's name is a required field!")]
        [MinLength(2, ErrorMessage = "Name must be from 2 to 120 chars long!")]
        [MaxLength(120, ErrorMessage = "Name must be from 2 to 120 chars long!")]
        public string Name { get; set; }

        [MinLength(2, ErrorMessage = "Speciality must be at least 2 chars long!")]
        public string Speciality { get; set; }

        public virtual HashSet<Visitation> Visitations { get; set; }
    }
}
