using Problem7_FoodShortage.Interfaces;
using Problem7_FoodShortage.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem7_FoodShortage
{
    class Startup
    {
        private static void Main(string[] args)
        {
            var n = int.Parse(Console.ReadLine());

            ICollection<IPerson> people = new List<IPerson>();

            for (int i = 0; i < n; i++)
            {
                var tokens = Console.ReadLine().Split().ToList();

                if (tokens.Count == 4)
                {
                    people.Add(new Citizen(tokens[0], int.Parse(tokens[1]), tokens[2], tokens[3]));
                }
                else if (tokens.Count == 3)
                {
                    people.Add(new Rebel(tokens[0], int.Parse(tokens[1]), tokens[2]));
                }
            }

            var input = string.Empty;

            while ((input = Console.ReadLine()) != "End")
            {
                if (people.Any(p => p.Name == input))
                {
                    var person = people.First(p => p.Name == input);
                    person.BuyFood();
                }
            }

            var foodCount = people.Sum(p => p.Food);

            Console.WriteLine(foodCount);
        }
    }
}