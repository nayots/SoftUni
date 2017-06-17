using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem7_PredicateForNames
{
    class PredicateForNames
    {
        private static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            Predicate<string> isInLimit = (w) => w.Length <= n;

            var names = Console.ReadLine().Split(new char[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Where(w => isInLimit(w));

            Console.WriteLine(string.Join("\n", names));
        }
    }
}