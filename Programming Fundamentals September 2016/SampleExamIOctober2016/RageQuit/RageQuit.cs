using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Text.RegularExpressions;
//03. Rage Quit
namespace RageQuit
{
    class RageQuit
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine().ToUpper();
            string pattern = @"(\D+)(\d+)";
            Regex rgx = new Regex(pattern);
            int count = 0;
            StringBuilder sb = new StringBuilder();

            MatchCollection matches = rgx.Matches(input);

            StringBuilder msg = new StringBuilder();
            foreach (Match match in matches)
            {
                int repetitions = int.Parse(match.Groups[2].ToString());
                string message = match.Groups[1].ToString();


                for (int i = 0; i < repetitions; i++)
                {
                    msg.Append(message);
                }
            }
            count = msg.ToString().Distinct().Count();
            Console.WriteLine($"Unique symbols used: {count}");
            Console.WriteLine(msg);
        }
    }
}