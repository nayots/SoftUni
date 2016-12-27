using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace WaterSupplies
{
    class WaterSupplies
    {
        static void Main(string[] args)
        {
            decimal waterSupply = decimal.Parse(Console.ReadLine());

            List<decimal> waterBottles = Console.ReadLine().Split(' ').Select(decimal.Parse).ToList();

            decimal bottleCapacity = decimal.Parse(Console.ReadLine());


            List<int> indexes = new List<int>();

            int bottleEndIndex = -1;

            if (waterSupply % 2 == 0)
            {

                for (int i = 0; i < waterBottles.Count; i++)
                {
                    decimal refill = bottleCapacity - waterBottles[i];

                    if (waterSupply > refill)
                    {
                        waterSupply -= refill;
                        waterBottles[i] += (refill);
                    }
                    else
                    {
                        waterBottles[i] += waterSupply;
                        waterSupply = 0;
                        
                        if (waterBottles[i] < bottleCapacity)
                        {
                            bottleEndIndex = i;
                            for (int j = i; j < waterBottles.Count; j++)
                            {
                                indexes.Add(j);
                            }
                            break;
                        }
                    }
                }
            }
            else
            {
                for (int i = waterBottles.Count - 1; i >= 0; i--)
                {
                    decimal refill = bottleCapacity - waterBottles[i];

                    if (waterSupply > refill)
                    {
                        waterSupply -= refill;
                        waterBottles[i] += (refill);
                    }
                    else
                    {
                        waterBottles[i] += waterSupply;
                        waterSupply = 0;
                        
                        if (waterBottles[i] < bottleCapacity)
                        {
                            bottleEndIndex = i;
                            for (int j = i; j >= 0; j--)
                            {
                                indexes.Add(j);
                            }
                            break;
                        }
                    }
                }
            }


            if (bottleEndIndex == -1)
            {
                Console.WriteLine("Enough water!");
                Console.WriteLine($"Water left: {waterSupply}l.");
            }
            else
            {
                decimal waterNeeded = 0;

                foreach (var indx in indexes)
                {
                    waterNeeded += (bottleCapacity - waterBottles[indx]);
                }


                Console.WriteLine("We need more water!");
                Console.WriteLine($"Bottles left: {indexes.Count}");
                Console.WriteLine($"With indexes: {string.Join(", ", indexes)}");
                Console.WriteLine($"We need {waterNeeded} more liters!");
            }
        }
    }
}
