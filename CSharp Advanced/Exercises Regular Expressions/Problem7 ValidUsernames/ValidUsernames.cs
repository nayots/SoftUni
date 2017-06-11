using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Problem7_ValidUsernames
{
    class ValidUsernames
    {
        private static void Main(string[] args)
        {
            var input = Console.ReadLine();
            string pattern = @"\b[a-zA-Z]+\d*\w*";
            Regex rgx = new Regex(pattern);

            var usernames = input.Split(new[] { ' ', '/', '\\', '(', ')' }, StringSplitOptions.RemoveEmptyEntries);

            var validNames = new List<string>();
            var maxLenght = 0;
            int firstWordIndex = -1;
            int secondWordIndex = -1;

            foreach (var username in usernames)
            {
                if (rgx.Match(username).Success && username.Length >= 3 && username.Length <= 25)
                {
                    validNames.Add(username);
                }
            }

            for (int i = 0; i < validNames.Count - 1; i++)
            {
                if ((validNames[i].Length + validNames[i + 1].Length) > maxLenght)
                {
                    maxLenght = validNames[i].Length + validNames[i + 1].Length;
                    firstWordIndex = i;
                    secondWordIndex = i + 1;
                }
            }

            Console.WriteLine(validNames[firstWordIndex]);
            Console.WriteLine(validNames[secondWordIndex]);
        }
    }
}