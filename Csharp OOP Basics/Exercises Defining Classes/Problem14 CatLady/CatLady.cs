using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem14_CatLady
{
    class CatLady
    {
        private static void Main(string[] args)
        {
            List<Cat> cats = new List<Cat>();

            var input = string.Empty;

            while ((input = Console.ReadLine()) != "End")
            {
                var tokens = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                switch (tokens[0])
                {
                    case "Siamese":
                        cats.Add(new Siamese(tokens[1], int.Parse(tokens[2])));
                        break;

                    case "Cymric":
                        cats.Add(new Cymric(tokens[1], double.Parse(tokens[2])));
                        break;

                    case "StreetExtraordinaire":
                        cats.Add(new StreetExtraordinaire(tokens[1], int.Parse(tokens[2])));
                        break;
                }
            }

            var catName = Console.ReadLine();

            var cat = cats.FirstOrDefault(c => c.Name == catName);

            Console.WriteLine(cat.ToString());
        }
    }
}