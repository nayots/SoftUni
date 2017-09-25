using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace FootballBetting.Models
{
    public class Country
    {
        [Key]
        [Required]
        [MinLength(3)]
        [MaxLength(3)]
        public string Id { get; set; }

        [Required]
        public string Name { get; set; }

        public int ContinentId { get; set; }

        public ICollection<CountryContinent> Continents { get; set; } = new List<CountryContinent>();

        public ICollection<Town> Towns { get; set; } = new List<Town>();
    }
}