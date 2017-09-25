using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FootballBetting.Models
{
    public class Competition
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int CompetitionTypeId { get; set; }

        public CompetitionType CompetitionType { get; set; }

        public ICollection<Game> Games { get; set; } = new List<Game>();
    }
}