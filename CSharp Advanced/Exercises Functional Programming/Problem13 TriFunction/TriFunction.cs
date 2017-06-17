using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem13_TriFunction
{
    class TriFunction
    {
        private static void Main(string[] args)
        {
            Func<string, int, bool> isLongEnough = (w, n) =>
            {
                var sumOfChars = 0;

                foreach (var c in w)
                {
                    sumOfChars += c;
                }

                if (sumOfChars >= n)
                {
                    return true;
                }
                else
                {
                    return false;
                }
            };

            int limit = int.Parse(Console.ReadLine());
            var names = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            string result = FindMatchingName(isLongEnough, names, limit);

            Console.WriteLine(result);
        }

        private static string FindMatchingName(Func<string, int, bool> isLongEnough, string[] names, int limit)
        {
            string res = "";

            foreach (var name in names)
            {
                if (isLongEnough(name, limit))
                {
                    res = name;
                    break;
                }
            }

            return res;
        }
    }
}