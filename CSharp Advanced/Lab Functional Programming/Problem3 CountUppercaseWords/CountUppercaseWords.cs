using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem3_CountUppercaseWords
{
    class CountUppercaseWords
    {
        private static void Main(string[] args)
        {
            Console.WriteLine(string.Join("\n", Console.ReadLine()
                .Split(new[] { '\n', '\r', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .Where(w => w[0].ToString() == w[0].ToString().ToUpper())));
        }
    }
}