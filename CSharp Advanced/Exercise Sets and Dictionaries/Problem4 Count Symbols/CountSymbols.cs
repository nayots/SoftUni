using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem4_Count_Symbols
{
    class CountSymbols
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            var symbolData = new SortedDictionary<char, int>();

            foreach (var c in input)
            {
                if (symbolData.ContainsKey(c))
                {
                    symbolData[c] += 1;
                }
                else
                {
                    symbolData.Add(c, 1);
                }
            }

            foreach (var res in symbolData)
            {
                Console.WriteLine($"{res.Key}: {res.Value} time/s");
            }
        }
    }
}
