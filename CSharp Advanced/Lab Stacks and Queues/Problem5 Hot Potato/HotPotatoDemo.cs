using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem5_Hot_Potato
{
    class HotPotatoDemo
    {
        static void Main(string[] args)
        {
            Queue<string> names = new Queue<string>(Console.ReadLine().Split().ToArray());

            int n = int.Parse(Console.ReadLine());
            int count = 1;
            while (names.Count > 1)
            {
                var name = names.Dequeue();
                if (count == n)
                {
                    count = 1;
                    Console.WriteLine($"Removed {name}");
                }
                else
                {
                    names.Enqueue(name);
                    count++;
                }

            }
            var lastName = names.Dequeue();
            Console.WriteLine($"Last is {lastName}");
        }
    }
}
