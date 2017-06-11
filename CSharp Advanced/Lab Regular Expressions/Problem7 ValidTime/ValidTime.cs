using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Problem7_ValidTime
{
    class ValidTime
    {
        private static void Main(string[] args)
        {
            var pattern = @"[01][0-9]:[0-5][\d]:[0-5][\d] (A|P)M";
            Regex rgx = new Regex(pattern);

            var input = Console.ReadLine();

            if (input == "END")
            {
                return;
            }
            while (input != "END")
            {
                if (rgx.Match(input).Success)
                {
                    Console.WriteLine("valid");
                }
                else
                {
                    Console.WriteLine("invalid");
                }
                input = Console.ReadLine();
            }
        }
    }
}