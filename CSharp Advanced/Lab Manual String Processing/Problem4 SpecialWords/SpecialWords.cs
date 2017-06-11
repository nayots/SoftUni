using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem4_SpecialWords
{
    class SpecialWords
    {
        private static void Main(string[] args)
        {
            char[] separators = new char[] { '(', ')', '[', ']', '<', '>', ',', '-', '!', '?', ' ' };

            var specialWords = Console.ReadLine().Split(separators, StringSplitOptions.RemoveEmptyEntries);

            var wordsToCheck = Console.ReadLine().Split(separators, StringSplitOptions.RemoveEmptyEntries);

            var results = new Dictionary<string, int>();

            foreach (var specialWord in specialWords)
            {
                if (!results.ContainsKey(specialWord))
                {
                    results.Add(specialWord, 0);
                }
            }

            for (int i = 0; i < specialWords.Length; i++)
            {
                for (int j = 0; j < wordsToCheck.Length; j++)
                {
                    if (wordsToCheck[j].Equals(specialWords[i]))
                    {
                        if (results.ContainsKey(specialWords[i]))
                        {
                            results[specialWords[i]] += 1;
                        }
                        else
                        {
                            results.Add(specialWords[i], 1);
                        }
                    }
                }
            }

            foreach (var word in results)
            {
                Console.WriteLine($"{word.Key} - {word.Value}");
            }
        }
    }
}