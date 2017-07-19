using Problem6_BirthdayCelebrations.Interfaces;
using Problem6_BirthdayCelebrations.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem6_BirthdayCelebrations
{
    class Startup
    {
        private static void Main(string[] args)
        {
            var input = string.Empty;

            ICollection<IBeing> aiBeings = new List<IBeing>();
            ICollection<IBirthable> livingbeings = new List<IBirthable>();

            while ((input = Console.ReadLine()) != "End")
            {
                var tokens = input.Split().ToList();
                var type = tokens[0];
                tokens.Remove(tokens.First());

                if (type == "Citizen")
                {
                    livingbeings.Add(new Citizen(tokens[0], int.Parse(tokens[1]), tokens[2], tokens[3]));
                }
                else if (type == "Robot")
                {
                    aiBeings.Add(new Robot(tokens[0], tokens[1]));
                }
                else if (type == "Pet")
                {
                    livingbeings.Add(new Pet(tokens[0], tokens[1]));
                }
            }

            string year = Console.ReadLine();

            livingbeings.Where(l => l.BirthDate.EndsWith(year)).ToList().ForEach(x => Console.WriteLine(x.BirthDate));
        }
    }
}