using HospitalDB.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalDB.Models
{
    public class Medicament
    {
        public Medicament()
        {
            this.Patients = new HashSet<Patient>();
        }

        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "Medicament name is required!")]
        public string Name { get; set; }

        public virtual HashSet<Patient> Patients { get; set; }
    }
}
