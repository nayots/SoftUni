using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem6_Math_Potato
{
    class MathPotatoDemo
    {
        static void Main(string[] args)
        {
            Queue<string> names = new Queue<string>(Console.ReadLine().Split().ToArray());

            int n = int.Parse(Console.ReadLine());
            int cycle = 1;
            while (names.Count > 1)
            {
                for (int i = 1; i < n; i++)
                {
                    names.Enqueue(names.Dequeue());
                }
                if (IsPrime(cycle))
                {
                    Console.WriteLine($"Prime {names.Peek()}");
                }
                else
                {
                    Console.WriteLine($"Removed {names.Dequeue()}");
                }
                cycle++;
            }
            var lastName = names.Dequeue();
            Console.WriteLine($"Last is {lastName}");
        }

        private static bool IsPrime(int n)
        {
            bool primeCheck = true;
            if (n == 0 || n == 1)
            {
                primeCheck = false;
                return primeCheck;
            }
            else
            {
                for (int i = 2; i <= Math.Sqrt(n); i++)
                {
                    if (n % i == 0)
                    {
                        primeCheck = false;
                    }
                }
                return primeCheck;
            }
        }
    }
}
