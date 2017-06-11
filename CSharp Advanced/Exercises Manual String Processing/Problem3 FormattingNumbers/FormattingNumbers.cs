using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem3_FormattingNumbers
{
    class FormattingNumbers
    {
        private static void Main(string[] args)
        {
            var inputArgs = Console.ReadLine().Split(new[] { ' ', '\t', '\n' }, StringSplitOptions.RemoveEmptyEntries);

            int a = int.Parse(inputArgs[0]);
            double b = double.Parse(inputArgs[1]);
            double c = double.Parse(inputArgs[2]);

            //var watch = Stopwatch.StartNew();

            var binary = Convert.ToString(a, 2);
            var hex = a.ToString("X");

            //<option1>

            //string hexNumber = hex.PadRight(10);
            //string binaryNumber = binary.PadLeft(10, '0').Substring(0, 10);
            //string doubleOne = b.ToString("0.00").PadLeft(10);
            //string doubleTwo = c.ToString("0.000").PadRight(10);
            //string res = $"|{hexNumber}|{binaryNumber}|{doubleOne}|{doubleTwo}|";
            //Console.WriteLine(res);

            //</option1>

            //watch.Stop();
            //Console.WriteLine(watch.ElapsedTicks);

            //watch.Restart();

            //<option2> This is more than 2 times faster than option1
            Console.WriteLine(string.Format("|{0,-10}|{1}|{2,10:F2}|{3,-10:F3}|", hex, binary.PadLeft(10, '0').Substring(0, 10), b, c));
            //</option2>

            //watch.Stop();
            //Console.WriteLine(watch.ElapsedTicks);
        }
    }
}