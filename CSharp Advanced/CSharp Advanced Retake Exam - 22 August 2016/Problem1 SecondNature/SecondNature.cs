using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem1_SecondNature
{
    class SecondNature
    {
        private static void Main(string[] args)
        {
            var flowers = new Queue<int>(Console.ReadLine().Split().Select(int.Parse));
            var buckets = new Stack<int>(Console.ReadLine().Split().Select(int.Parse));

            Queue<int> sn = new Queue<int>();

            while (flowers.Count > 0 && buckets.Count > 0)
            {
                var currentFlower = flowers.Peek();

                var currentBucket = buckets.Pop();

                if (currentBucket > currentFlower)
                {
                    currentBucket = currentBucket - currentFlower;
                    flowers.Dequeue();
                    var nextBucket = currentBucket;
                    if (buckets.Count > 0)
                    {
                        nextBucket += buckets.Pop();
                    }
                    buckets.Push(nextBucket);
                }
                else if (currentFlower == currentBucket)
                {
                    sn.Enqueue(currentFlower);
                    flowers.Dequeue();
                }
                else
                {
                    var flower = flowers.Dequeue();
                    flower = flower - currentBucket;
                    var items = flowers.ToArray();
                    flowers.Clear();
                    flowers.Enqueue(flower);
                    foreach (var item in items)
                    {
                        flowers.Enqueue(item);
                    }
                }
            }

            if (flowers.Count > 0)
            {
                Console.WriteLine(string.Join(" ", flowers));
            }
            else
            {
                Console.WriteLine(string.Join(" ", buckets));
            }

            if (sn.Count > 0)
            {
                Console.WriteLine(string.Join(" ", sn));
            }
            else
            {
                Console.WriteLine("None");
            }
        }
    }
}