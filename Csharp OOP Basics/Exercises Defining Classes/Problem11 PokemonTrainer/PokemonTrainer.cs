using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem11_PokemonTrainer
{
    class PokemonTrainer
    {
        private static void Main(string[] args)
        {
            string input = "";

            List<Trainer> trainers = new List<Trainer>();

            while ((input = Console.ReadLine()) != "Tournament")
            {
                var tokens = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                var tName = tokens[0];
                var pName = tokens[1];
                var pEle = tokens[2];
                var pHp = int.Parse(tokens[3]);

                if (trainers.Any(t => t.Name == tName))
                {
                    var trainer = trainers.FirstOrDefault(t => t.Name == tName);

                    var poke = new Pokemon(pName, pEle, pHp);
                    trainer.Pokemons.Add(poke);
                }
                else
                {
                    trainers.Add(new Trainer(tName, 0, new List<Pokemon>() { new Pokemon(pName, pEle, pHp) }));
                }
            }

            while ((input = Console.ReadLine()) != "End")
            {
                var element = input;

                foreach (var tr in trainers)
                {
                    if (tr.Pokemons.Any(p => p.Element == element))
                    {
                        tr.BadgesCount++;
                    }
                    else
                    {
                        for (int i = 0; i < tr.Pokemons.Count; i++)
                        {
                            tr.Pokemons[i].Hp -= 10;
                            if (tr.Pokemons[i].Hp <= 0)
                            {
                                tr.Pokemons.RemoveAt(i);
                                i--;
                            }
                        }
                    }
                }
            }

            foreach (var trainer in trainers.OrderByDescending(t => t.BadgesCount))
            {
                Console.WriteLine($"{trainer.Name} {trainer.BadgesCount} {trainer.Pokemons.Count}");
            }
        }
    }
}