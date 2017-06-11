using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem15_MelrahShake
{
    class MelrahShake
    {
        private static void Main(string[] args)
        {
            string input = Console.ReadLine();
            string pattern = Console.ReadLine();

            bool canShake = true;

            while (canShake)
            {
                int indxFirst = input.IndexOf(pattern);
                int indxLast = input.LastIndexOf(pattern);
                if (indxFirst > -1 && indxLast > -1 && pattern.Length > 0)
                {
                    input = input.Remove(indxFirst, pattern.Length);
                    indxLast = input.LastIndexOf(pattern);
                    input = input.Remove(indxLast, pattern.Length);
                    Console.WriteLine("Shaked it.");
                    if (pattern.Length > 0)
                    {
                        pattern = pattern.Remove(pattern.Length / 2, 1);
                    }
                }
                else
                {
                    Console.WriteLine("No shake.");
                    canShake = false;
                    Console.WriteLine(input);
                    break;
                }
            }
        }
    }
}