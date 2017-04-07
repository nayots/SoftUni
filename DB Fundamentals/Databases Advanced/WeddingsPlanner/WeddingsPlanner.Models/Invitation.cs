using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using WeddingsPlanner.Models.enums;

namespace WeddingsPlanner.Models
{
    public class Invitation
    {
        [Key]
        public int Id { get; set; }

        [ForeignKey("Wedding")]
        public int WeddingId { get; set; }

        [Required]
        public virtual Wedding Wedding { get; set; }

        [ForeignKey("Guest")]
        public int GuestId { get; set; }

        [Required]
        public virtual Person Guest { get; set; }

        public virtual Present Present { get; set; }

        public bool IsAttending { get; set; }

        [Required]
        public Family Family { get; set; }
    }
}
