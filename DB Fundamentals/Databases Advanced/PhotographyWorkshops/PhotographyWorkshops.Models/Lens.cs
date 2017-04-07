using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PhotographyWorkshops.Models
{
    public class Lens
    {
        [Key]
        public int Id { get; set; }

        public string Make { get; set; }

        public int FocalLength { get; set; }

        public double MaxAperture { get; set; }

        public string CompatibleWith { get; set; }

        [ForeignKey("Owner")]
        public int? OwnerId { get; set; }

        public virtual Photographer Owner { get; set; }
    }
}
