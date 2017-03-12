using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StudentSystemDB.Models
{
    public enum ResourceType
    {
        video,
        presentation,
        document,
        other
    }
    public class Resource
    {
        public Resource()
        {
            this.Licenses = new List<License>();
        }

        [Key]
        public int Id { get; set; }

        [Required]
        [MinLength(1, ErrorMessage = "Minimum Length is 1 char!")]
        public string Name { get; set; }

        [Required(ErrorMessage = "Resource type is a required field!")]
        public ResourceType ResourceType { get; set; }

        [Required]
        [MinLength(3, ErrorMessage = "Minimum Length is 3 chars!")]
        public string URL { get; set; }

        [ForeignKey("Course")]
        public int CourseId { get; set; }

        public virtual Course Course { get; set; }

        public virtual ICollection<License> Licenses { get; set; }
    }
}
