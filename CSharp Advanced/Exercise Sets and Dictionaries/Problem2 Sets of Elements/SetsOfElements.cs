using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem2_Sets_of_Elements
{
    class SetsOfElements
    {
        static void Main(string[] args)
        {
            var setsArgs = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Select(int.Parse).ToArray();

            var n = setsArgs[0];
            var m = setsArgs[1];

            var nSet = new HashSet<int>();
            var mSet = new HashSet<int>();

            for (int i = 0; i < n; i++)
            {
                var num = int.Parse(Console.ReadLine());
                nSet.Add(num);
            }

            for (int j = 0; j < m; j++)
            {
                var num = int.Parse(Console.ReadLine());
                mSet.Add(num);
            }

            var results = nSet.Intersect(mSet);

            Console.WriteLine(string.Join(" ",results));
        }
    }
}
