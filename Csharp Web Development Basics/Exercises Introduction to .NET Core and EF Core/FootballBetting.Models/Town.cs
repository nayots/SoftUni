using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FootballBetting.Models
{
    public class Town
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public string CountryId { get; set; }

        public Country Country { get; set; }

        public ICollection<Team> Teams { get; set; } = new List<Team>();
    }
}