using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem6_A_Miner_s_Task
{
    class MinersTask
    {
        static void Main(string[] args)
        {
            Dictionary<string, int> mats = new Dictionary<string, int>();
            string material = Console.ReadLine();

            while (material != "stop")
            {
                int quantity = 0;

                quantity = int.Parse(Console.ReadLine());

                if (mats.ContainsKey(material))
                {
                    mats[material] += quantity;
                }
                else
                {
                    mats.Add(material, quantity);
                }
                material = Console.ReadLine();
            }
            PrintSortedResults(mats);
        }

        private static void PrintSortedResults(Dictionary<string, int> mats)
        {
            foreach (KeyValuePair<string, int> materials in mats)
            {
                Console.WriteLine($"{materials.Key} -> {materials.Value}");
            }
        }
    }
}
