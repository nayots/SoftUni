using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem11_PokemonTrainer
{
    public class Trainer
    {
        public Trainer(string name, int badges, ICollection<Pokemon> pokemons)
        {
            this.Name = name;
            this.BadgesCount = badges;
            this.Pokemons = new List<Pokemon>(pokemons);
        }

        public string Name { get; set; }
        public int BadgesCount { get; set; }
        public List<Pokemon> Pokemons { get; set; }
    }
}