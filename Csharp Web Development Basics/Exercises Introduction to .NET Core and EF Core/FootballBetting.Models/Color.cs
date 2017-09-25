using System.ComponentModel.DataAnnotations;

namespace FootballBetting.Models
{
    public class Color
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }
    }
}