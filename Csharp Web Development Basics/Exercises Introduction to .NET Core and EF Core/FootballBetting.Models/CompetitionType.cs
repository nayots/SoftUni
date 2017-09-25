using System.ComponentModel.DataAnnotations;

namespace FootballBetting.Models
{
    public class CompetitionType
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}