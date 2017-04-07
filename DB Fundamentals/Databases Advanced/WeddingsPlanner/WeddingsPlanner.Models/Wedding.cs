using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingsPlanner.Models
{
    public class Wedding
    {
        public Wedding()
        {
            this.Venues = new List<Venue>();
            this.Invitations = new List<Invitation>();
        }

        [Key]
        public int Id { get; set; }

        [ForeignKey("Bride")]
        public int BrideId { get; set; }

        [Required]
        public virtual Person Bride { get; set; }

        [ForeignKey("Bridegroom")]
        public int BridegroomId { get; set; }

        [Required]
        public virtual Person Bridegroom { get; set; }

        [Required]
        public DateTime Date { get; set; }
        
        [ForeignKey("Agency")]
        public int? AgencyId { get; set; }

        public virtual Agency Agency { get; set; }

        public virtual ICollection<Venue> Venues { get; set; }

        public virtual ICollection<Invitation> Invitations { get; set; }
    }
}
