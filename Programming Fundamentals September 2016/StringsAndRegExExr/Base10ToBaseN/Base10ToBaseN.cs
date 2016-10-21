using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;
//01. Convert from base-10 to base-N
namespace Base10ToBaseN
{
    class Base10ToBaseN
    {
        static void Main(string[] args)
        {
            string[] input = Console.ReadLine().Split(new char[] {' '},StringSplitOptions.RemoveEmptyEntries);
            long toBase = long.Parse(input[0]);
            BigInteger numberBaseTen = BigInteger.Parse(input[1]);

            StringBuilder result = new StringBuilder();

            while (numberBaseTen > 0)
            {
                BigInteger remainder = numberBaseTen % toBase;
                result.Insert(0,remainder.ToString());
                numberBaseTen /= toBase;
            }
            Console.WriteLine(result);
        }
    }
}
