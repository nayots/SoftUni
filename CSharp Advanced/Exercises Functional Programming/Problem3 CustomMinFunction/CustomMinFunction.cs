using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem3_CustomMinFunction
{
    class CustomMinFunction
    {
        private static void Main(string[] args)
        {
            Func<List<int>, int> min = (n) => n.Min();

            var numbers = Console.ReadLine().Split(new[] { ' ', '\t', '\n', '\r' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToList();

            Console.WriteLine(min(numbers));
        }
    }
}