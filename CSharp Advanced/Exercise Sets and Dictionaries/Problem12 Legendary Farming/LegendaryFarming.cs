using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem12_Legendary_Farming
{
    class LegendaryFarming
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, int> keyItems = new SortedDictionary<string, int> { { "shards", 0 }, { "fragments", 0 }, { "motes", 0 } };
            SortedDictionary<string, int> junkItems = new SortedDictionary<string, int>();

            while (true)
            {
                string loot = Console.ReadLine().ToLower();
                SortItems(loot, keyItems, junkItems);
                if (keyItems.Values.Max() >= 250)
                {
                    break;
                }
            }
            Results(keyItems, junkItems);
        }

        private static void Results(SortedDictionary<string, int> keyItems, SortedDictionary<string, int> junkItems)
        {
            string legendary = keyItems.Aggregate((comparison, current) => comparison.Value > current.Value ? comparison : current).Key;

            switch (legendary)
            {
                case "shards":
                    Console.WriteLine("Shadowmourne obtained!");
                    keyItems[legendary] -= 250;
                    PrintRest(keyItems, junkItems);
                    break;
                case "fragments":
                    Console.WriteLine("Valanyr obtained!");
                    keyItems[legendary] -= 250;
                    PrintRest(keyItems, junkItems);
                    break;
                case "motes":
                    Console.WriteLine("Dragonwrath obtained!");
                    keyItems[legendary] -= 250;
                    PrintRest(keyItems, junkItems);
                    break;
            }
        }

        private static void PrintRest(SortedDictionary<string, int> keyItems, SortedDictionary<string, int> junkItems)
        {
            foreach (KeyValuePair<string, int> leftOverKeyitems in keyItems.OrderByDescending(x => x.Value))
            {
                Console.WriteLine($"{leftOverKeyitems.Key}: {leftOverKeyitems.Value}");
            }

            foreach (KeyValuePair<string, int> leftOverJunkItems in junkItems)
            {
                Console.WriteLine($"{leftOverJunkItems.Key}: {leftOverJunkItems.Value}");
            }
        }

        private static void SortItems(string loot, SortedDictionary<string, int> keyItems, SortedDictionary<string, int> junkItems)
        {
            List<string> farmedItems = loot.Split().ToList();

            for (int i = 0; i < farmedItems.Count; i += 2)
            {
                int itemQuantity = int.Parse(farmedItems[i]);
                string item = farmedItems[i + 1];

                if (item == "shards" || item == "fragments" || item == "motes")
                {
                    AddToKeyItems(keyItems, item, itemQuantity);
                }
                else
                {
                    AddToJunkItems(junkItems, item, itemQuantity);
                }
                if (keyItems.Values.Max() >= 250)
                {
                    break;
                }
            }
        }

        private static void AddToJunkItems(SortedDictionary<string, int> junkItems, string item, int itemQuantity)
        {
            if (junkItems.ContainsKey(item))
            {
                junkItems[item] += itemQuantity;
            }
            else
            {
                junkItems.Add(item, itemQuantity);
            }
        }

        private static void AddToKeyItems(SortedDictionary<string, int> keyItems, string item, int itemQuantity)
        {
            if (keyItems.ContainsKey(item))
            {
                keyItems[item] += itemQuantity;
            }
            else
            {
                keyItems.Add(item, itemQuantity);
            }
        }
    }
}
