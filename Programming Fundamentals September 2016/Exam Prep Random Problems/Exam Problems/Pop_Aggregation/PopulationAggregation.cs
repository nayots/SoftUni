using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;

namespace Pop_Aggregation
{
    public class PopulationAggregation
    {
        static void Main(string[] args)
        {
            string command = Console.ReadLine();

            List<Country> countries = new List<Country>();

            while (command != "stop")
            {
                string[] commandArgs = command.Split('\\');

                string country = "";
                string city = "";

                if (char.IsUpper(commandArgs[0][0]))
                {
                    country = commandArgs[0];
                    city = commandArgs[1];
                }
                else
                {
                    country = commandArgs[1];
                    city = commandArgs[0];
                }

                long population = long.Parse(commandArgs[2]);

                //    \@|\#|\$|\&|[0-9]    removes all the unwanted symbols when used with Regex.Replace

                country = Regex.Replace(country, @"\@|\#|\$|\&|[0-9]", string.Empty);

                city = Regex.Replace(city, @"\@|\#|\$|\&|[0-9]", string.Empty);


                if (countries.Any(x => x.Name == country))
                {
                    int cIndx = countries.FindIndex(x => x.Name == country);

                    City town = new City();
                    town.Name = city;
                    town.Population = population;

                    countries[cIndx].Cities.Add(town);

                    countries[cIndx].Cities
                        .Where(x => x.Name == city)
                        .Select(c => c.Population = population).ToList();
                }
                else
                {
                    Country newCountry = new Country();

                    newCountry.Name = country;

                    City town = new City();
                    town.Name = city;
                    town.Population = population;

                    newCountry.Cities.Add(town);

                    countries.Add(newCountry);
                }

                command = Console.ReadLine();
            }

            List<City> allTowns = new List<City>();

            foreach (var country in countries.OrderBy(x => x.Name))
            {
                Console.WriteLine($"{country.Name} -> {country.Cities.Count}");

                List<City> townsToadd = new List<City>();

                townsToadd = country.Cities.GroupBy(x => x.Name).Select(y => y.First()).ToList();// Groups all the towns by name , then takes the first entry from each group, then makes a list.

                allTowns.AddRange(townsToadd);
            }

            foreach (var town in allTowns.OrderByDescending(x => x.Population).Take(3))
            {
                Console.WriteLine($"{town.Name} -> {town.Population}");
            }

        }

    }

    public class Country
    {
        public string Name { get; set; }
        public List<City> Cities { get; set; } = new List<City>();
    }

    public class City
    {
        public string Name { get; set; }
        public long Population { get; set; }
    }
}
