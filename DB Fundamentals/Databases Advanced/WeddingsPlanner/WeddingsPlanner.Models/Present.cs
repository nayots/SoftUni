using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WeddingsPlanner.Models
{
    public class Present
    {
        [Key]
        public int Id { get; set; }

        [NotMapped]
        public virtual Person Owner { get { return this.Invitation.Guest; } }

        public virtual Invitation Invitation { get; set; }
    }
}
