using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem11_Plants
{
    internal class Plants
    {
        private static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            int[] initialPlants = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            Queue<int> plants = new Queue<int>(initialPlants.Reverse());

            bool toxicPlantsExist = true;
            int days = 0;
            while (toxicPlantsExist)
            {
                var count = plants.Count;
                for (int i = 0; i < count; i++)
                {
                    var currentPlant = plants.Dequeue();
                    if (i == count - 1)
                    {
                        plants.Enqueue(currentPlant);
                    }
                    else
                    {
                        if (currentPlant <= plants.Peek())
                        {
                            plants.Enqueue(currentPlant);
                        }
                    }
                }

                if (count == plants.Count)
                {
                    toxicPlantsExist = false;
                    break;
                }
                days++;
            }

            Console.WriteLine(days);
        }
    }
}