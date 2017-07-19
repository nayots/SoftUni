using Problem5_BorderControl.Interfaces;
using Problem5_BorderControl.Models;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem5_BorderControl
{
    class Startup
    {
        private static void Main(string[] args)
        {
            var input = string.Empty;

            ICollection<IBeing> beings = new List<IBeing>();

            while ((input = Console.ReadLine()) != "End")
            {
                var tokens = input.Split();

                if (tokens.Length == 3)
                {
                    beings.Add(new Citizen(tokens[0], int.Parse(tokens[1]), tokens[2]));
                }
                else
                {
                    beings.Add(new Robot(tokens[0], tokens[1]));
                }
            }

            string fakeIdEnd = Console.ReadLine();

            beings.Where(b => b.Id.EndsWith(fakeIdEnd)).ToList().ForEach(f => Console.WriteLine(f.Id));
        }
    }
}