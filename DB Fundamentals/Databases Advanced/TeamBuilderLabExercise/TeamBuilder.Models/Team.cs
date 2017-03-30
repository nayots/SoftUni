using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamBuilder.Models
{
    public class Team
    {
        [Key]
        public int Id { get; set; }

        [MaxLength(25)]
        [Required]
        public string Name { get; set; }

        public string Description { get; set; }

        [StringLength(3, MinimumLength = 3)]
        [Required]
        public string Acronym { get; set; }

        [ForeignKey("Creator")]
        public int CreatorId { get; set; }

        public virtual User Creator { get; set; }

        public virtual ICollection<User> Members { get; set; }

        public virtual ICollection<Event> ParticipatedEvents { get; set; }

        public virtual ICollection<Invitation> Invitations { get; set; }
    }
}
