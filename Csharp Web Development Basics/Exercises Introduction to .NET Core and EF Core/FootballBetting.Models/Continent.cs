using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FootballBetting.Models
{
    public class Continent
    {
        public int Id { get; set; }

        [Required]
        public string Name { get; set; }

        public ICollection<CountryContinent> Countries { get; set; } = new List<CountryContinent>();
    }
}