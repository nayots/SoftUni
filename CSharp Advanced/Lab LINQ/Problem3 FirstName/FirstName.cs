using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem3_FirstName
{
    class FirstName
    {
        private static void Main(string[] args)
        {
            var names = Console.ReadLine().Split().OrderBy(l => l);
            var letters = Console.ReadLine().Split().Select(c => c.ToLower()).OrderBy(l => l);

            var results = new List<string>();

            foreach (var letter in letters)
            {
                results.AddRange(names.Where(n => n.ToLower().StartsWith(letter)));
            }

            if (results.Count > 0)
            {
                Console.WriteLine(results.FirstOrDefault());
            }
            else
            {
                Console.WriteLine("No match");
            }
        }
    }
}