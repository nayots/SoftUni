using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using HospitalDB.Models;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HospitalDB.Models
{
    public class Patient
    {
        public Patient()
        {
            this.Medicaments = new HashSet<Medicament>();
            this.Visitations = new HashSet<Visitation>();
            this.Diagnoses = new HashSet<Diagnose>();
        }

        [Key]
        public int Id { get; set; }

        [MinLength(2, ErrorMessage = "First Name must be between 2 and 120 characters")]
        [MaxLength(120, ErrorMessage = "First Name must be between 2 and 120 characters")]
        [Required(ErrorMessage ="First Name is required")]
        public string FirstName { get; set; }

        [MinLength(2, ErrorMessage = "Last Name must be between 2 and 120 characters")]
        [MaxLength(120, ErrorMessage = "Last Name must be between 2 and 120 characters")]
        [Required(ErrorMessage = "Last Name is required")]
        public string LastName { get; set; }

        public string Address { get; set; }

        [RegularExpression(@"^([A-Za-z0-9]+)([\w\.\-]*)([A-Za-z0-9]+)@([[A-Za-z0-9]+(\-*[A-Za-z0-9])*)((\.([A-Za-z0-9]){2,3})+)$")]
        [Required]
        public string Email { get; set; }

        [Required(ErrorMessage = "Date of birth if required")]
        public DateTime DateOfBirth { get; set; }

        [MaxLength(1000000)]
        public byte[] Picture { get; set; }

        [Required(ErrorMessage = "You must specify if the patient is insured")]
        public bool IsInsured { get; set; }

        public virtual HashSet<Visitation> Visitations { get; set; }

        public virtual HashSet<Diagnose> Diagnoses { get; set; }

        public virtual HashSet<Medicament> Medicaments { get; set; }

    }
}
