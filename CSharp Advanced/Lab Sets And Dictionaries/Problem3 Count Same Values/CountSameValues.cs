using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem3_Count_Same_Values
{
    class CountSameValues
    {
        static void Main(string[] args)
        {
            var dict = new SortedDictionary<double, int>();

            var input = Console.ReadLine().Replace(',','.');

            var nums = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(double.Parse).ToArray();

            foreach (var num in nums)
            {
                if (dict.ContainsKey(num))
                {
                    dict[num] += 1;
                }
                else
                {
                    dict.Add(num, 1);
                }
            }

            foreach (var res in dict)
            {
                Console.WriteLine($"{res.Key} - {res.Value} times");
            }
        }
    }
}
