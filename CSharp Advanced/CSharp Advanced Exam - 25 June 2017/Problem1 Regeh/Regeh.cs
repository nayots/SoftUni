using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Problem1_Regeh
{
    class Regeh
    {
        private static void Main(string[] args)
        {
            string pattern = @"\[[^\[\s]+<(\d+)REGEH(\d+)>[^\s]*?\]";

            var input = Console.ReadLine();

            Regex rgx = new Regex(pattern);

            MatchCollection matches = rgx.Matches(input);

            int index = 0;
            int lenght = input.Length;

            string result = string.Empty;

            foreach (Match match in matches)
            {
                int digitOne = int.Parse(match.Groups[1].Value);
                int digitTwo = int.Parse(match.Groups[2].Value);

                index += digitOne;
                //IndexOne
                if (index >= input.Length)
                {
                    var realIndex = (index % input.Length) + 1;

                    result += input[realIndex];
                }
                else
                {
                    result += input[index];
                }

                //IndexTwo
                index += digitTwo;
                if (index >= input.Length)
                {
                    var realIndex = (index % input.Length) + 1;

                    result += input[realIndex];
                }
                else
                {
                    result += input[index];
                }
            }

            Console.WriteLine(result);
        }
    }
}