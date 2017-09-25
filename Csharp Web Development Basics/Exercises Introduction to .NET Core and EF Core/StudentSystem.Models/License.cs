using System.ComponentModel.DataAnnotations;

namespace StudentSystem.Models
{
    public class License
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int ResourceId { get; set; }

        public Resource Resource { get; set; }
    }
}