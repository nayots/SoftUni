using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotographyWorkshops.Models
{
    public class Photographer
    {
        public Photographer()
        {
            this.Lenses = new List<Lens>();
            this.Accessories = new List<Accessory>();
            this.WorkshopsParticipating = new List<Workshop>();
            this.WorkshopsAsTrainer = new List<Workshop>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        public string FirstName { get; set; }

        [Required]
        [MinLength(2)]
        [MaxLength(50)]
        public string LastName { get; set; }

        [RegularExpression(@"^\+[\d]{1,3}\/[\d]{8,10}$")]
        public string Phone { get; set; }

        [ForeignKey("PrimaryCamera")]
        public int PrimaryCameraId { get; set; }

        [Required]
        public virtual Camera PrimaryCamera { get; set; }

        [ForeignKey("SecondaryCamera")]
        public int SecondaryCameraId { get; set; }

        [Required]
        public virtual Camera SecondaryCamera { get; set; }

        public virtual ICollection<Lens> Lenses { get; set; }

        public virtual ICollection<Accessory> Accessories { get; set; }

        public virtual ICollection<Workshop> WorkshopsParticipating { get; set; }

        public virtual ICollection<Workshop> WorkshopsAsTrainer { get; set; }
    }
}
