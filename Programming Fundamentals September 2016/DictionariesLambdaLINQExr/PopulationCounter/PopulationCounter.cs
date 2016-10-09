using System;
using System.Collections.Generic;
using System.Linq;
//07. Population Counter
namespace PopulationCounter
{
    class PopulationCounter
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, long>> countries = new Dictionary<string, Dictionary<string, long>>();

            string command = Console.ReadLine();
            while (command != "report")
            {
                TreatRawData(countries, command);
                command = Console.ReadLine();
            }
            PrintReport(countries);
            Console.WriteLine();
        }

        private static void PrintReport(Dictionary<string, Dictionary<string, long>> countries)
        {
            foreach (var c in countries.OrderByDescending(x => x.Value.Values.Sum()))
            {
                string name = c.Key.ToString();
                Console.WriteLine($"{c.Key} (total population: {c.Value.Values.Sum()})");
                foreach (var city in c.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"=>{city.Key}: {city.Value}");
                }
            }
        }

        private static void TreatRawData(Dictionary<string, Dictionary<string, long>> countries, string command)
        {
            List<string> lineInput = command.Split('|').ToList();
            string city = lineInput[0];
            string country = lineInput[1];
            long popu = long.Parse(lineInput[2]);

            if (countries.ContainsKey(country))
            {
                if (countries[country].ContainsKey(city))
                {
                    countries[country][city] += popu;
                }
                else
                {
                    countries[country].Add(city, popu);
                }
            }
            else
            {
                countries.Add(country, new Dictionary<string, long> { { city, popu } });
            }
        }
    }
}
