using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FootballBetting.Models
{
    public class Position
    {
        [Key]
        [Required]
        [MinLength(2)]
        [MaxLength(2)]
        public string Id { get; set; }

        [Required]
        public string Description { get; set; }

        public ICollection<Player> Players { get; set; } = new List<Player>();
    }
}