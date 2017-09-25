using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FootballBetting.Models
{
    public class Team
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public byte[] Logo { get; set; }

        [Required]
        [MinLength(3)]
        [MaxLength(3)]
        public string Initials { get; set; }

        public int PrimaryColorId { get; set; }

        public Color PrimaryColor { get; set; }

        public int SecondaryColorId { get; set; }

        public Color SecondaryColor { get; set; }

        public int TownId { get; set; }

        public Town Town { get; set; }

        [Required]
        public decimal Budget { get; set; }

        public ICollection<Player> Players { get; set; } = new List<Player>();

        public ICollection<Game> GamesAsHosts { get; set; } = new List<Game>();

        public ICollection<Game> GamesAsGuests { get; set; } = new List<Game>();
    }
}