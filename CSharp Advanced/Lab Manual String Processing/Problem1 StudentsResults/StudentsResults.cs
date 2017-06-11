using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem1_StudentsResults
{
    class StudentsResults
    {
        private static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            Console.WriteLine(string.Format("{0, -10}|{1,7}|{2,7}|{3,7}|{4,7}|", "Name", "CAdv", "COOP", "AdvOOP", "Average"));
            for (int i = 0; i < n; i++)
            {
                string input = Console.ReadLine();

                input.Replace('-', ' ');
                input.Replace(',', ' ');
                var tokens = input.Split(new[] { ' ', '-', ',' }, StringSplitOptions.RemoveEmptyEntries);

                var numbers = tokens.Skip(1).Select(decimal.Parse).ToArray();

                var avg = numbers.Average();

                Console.WriteLine(string.Format("{0,-10}|{1,7:F2}|{2,7:F2}|{3,7:F2}|{4,7:F4}|", tokens[0], numbers[0], numbers[1], numbers[2], avg));
            }
        }
    }
}