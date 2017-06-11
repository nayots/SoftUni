using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Problem6_ValidUsernames
{
    class ValidUsernames
    {
        private static void Main(string[] args)
        {
            var pattern = @"^([\w-]{3,16})$";
            Regex rgx = new Regex(pattern);
            var input = Console.ReadLine();
            if (input == "END")
            {
                Console.WriteLine("(no output)");
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