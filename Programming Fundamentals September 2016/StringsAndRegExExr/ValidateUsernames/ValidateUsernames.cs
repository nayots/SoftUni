using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
//12. Valid Usernames
namespace ValidateUsernames
{
    class ValidateUsernames
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            string pattern = @"\b([a-zA-Z][\w]{2,24})\b";

            Regex rgx = new Regex(pattern);

            MatchCollection matches = rgx.Matches(input);
            int bestSum = 0;
            int indexOne = 0;
            int indexTwo = 0;

            for (int i = 0; i < matches.Count-1; i++)
            {
                int currSum = matches[i].Groups[1].Length + matches[i + 1].Groups[1].Length;
                if (currSum > bestSum)
                {
                    bestSum = currSum;
                    indexOne = i;
                    indexTwo = i + 1;
                }
            }
            Console.WriteLine(matches[indexOne].Groups[1]);
            Console.WriteLine(matches[indexTwo].Groups[1]);
        }
    }
}
