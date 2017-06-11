using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem5_ConcatenateStrings
{
    class ConcatenateStrings
    {
        private static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            var sb = new StringBuilder();

            for (int i = 0; i < n; i++)
            {
                var word = Console.ReadLine();

                sb.Append(word + " ");
            }

            Console.WriteLine(sb.ToString());
        }
    }
}