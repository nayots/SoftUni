using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
//10. Сръбско Unleashed
namespace SerbianUnleashed
{
    class SerbianUnleashed
    {
        static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int>> venuesSingersAndMoney = new Dictionary<string, Dictionary<string, int>>();

            string command = Console.ReadLine();

            while (command != "End")
            {
                RawDataProcessor(command, venuesSingersAndMoney);
                command = Console.ReadLine();
            }
            PrintResults(venuesSingersAndMoney);
        }

        private static void PrintResults(Dictionary<string, Dictionary<string, int>> venuesSingersAndMoney)
        {
            foreach (var venues in venuesSingersAndMoney)
            {
                Console.WriteLine(venues.Key);
                foreach (var singer in venues.Value.OrderByDescending(x => x.Value))
                {
                    Console.WriteLine($"#  {singer.Key} -> {singer.Value}");
                }
            }
        }

        private static void RawDataProcessor(string command, Dictionary<string, Dictionary<string, int>> venuesSingersAndMoney)
        {
            string pattern = @"([a-zA-Z]+\s){1,3}@([a-zA-Z0-9]+\s){1,3}[0-9]+\s[0-9]+";
            Regex regex = new Regex(pattern);
            bool hasMatch = regex.IsMatch(command);
            if (!hasMatch)
            {
                return;
            }

            Match matchData = Regex.Match(command, pattern);

            string lineInfo = matchData.Value;
            List<string> data = lineInfo.Split('@').ToList();

            string singer = data[0].Trim();
            string venue = Regex.Match(data[1], @"([a-zA-z]+\s){1,3}").Value.Trim();
            MatchCollection priceAndcount = Regex.Matches(data[1], @"[0-9]+");
            int ticketRevenue = int.Parse(priceAndcount[0].Value) * int.Parse(priceAndcount[1].Value);

            StoreData(venue, singer, ticketRevenue, venuesSingersAndMoney);
        }

        private static void StoreData(string venue, string singer, int ticketRevenue, Dictionary<string, Dictionary<string, int>> venuesSingersAndMoney)
        {
            if (venuesSingersAndMoney.ContainsKey(venue))
            {
                if (venuesSingersAndMoney[venue].ContainsKey(singer))
                {
                    venuesSingersAndMoney[venue][singer] += ticketRevenue;
                }
                else
                {
                    venuesSingersAndMoney[venue].Add(singer, ticketRevenue);
                }
            }
            else
            {
                venuesSingersAndMoney.Add(venue, new Dictionary<string, int> { { singer, ticketRevenue } });
            }
        }
    }
}
