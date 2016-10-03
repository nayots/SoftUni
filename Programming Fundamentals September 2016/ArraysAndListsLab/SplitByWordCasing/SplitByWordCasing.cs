using System;
using System.Collections.Generic;
using System.Linq;
//13. Split by Word Casing
namespace SplitByWordCasing
{
    class SplitByWordCasing
    {
        static void Main(string[] args)
        {
            List<string> words = Console.ReadLine()
                .Split(new char[] { ',', ';', ':', '.', '!', '(', ')', '"', '\'', '\\', '/', '[', ']', ' ' }, StringSplitOptions.RemoveEmptyEntries)
                .ToList();

            List<string> upCaseWords = new List<string>();
            List<string> lowCaseWords = new List<string>();
            List<string> mixedCaseWords = new List<string>();

            for (int i = 0; i < words.Count; i++)
            {
                bool hasAllUpC = true;
                bool hasAllLowC = true;

                foreach (char chara in words[i])
                {
                    if (char.IsUpper(chara))
                    {
                        hasAllLowC = false;
                    }
                    else if (char.IsLower(chara))
                    {
                        hasAllUpC = false;
                    }
                    else
                    {
                        hasAllLowC = false;
                        hasAllUpC = false;
                    }
                }
                if (hasAllUpC == true && hasAllLowC == false)
                {
                    upCaseWords.Add(words[i]);
                }
                else if (hasAllUpC == false && hasAllLowC == true)
                {
                    lowCaseWords.Add(words[i]);
                }
                else if ( hasAllUpC == false && hasAllLowC == false)
                {
                    mixedCaseWords.Add(words[i]);
                }
            }

            Console.WriteLine("Lower-case: " + string.Join(", ", lowCaseWords).TrimEnd(new char[] { ' ', ',' }));
            Console.WriteLine("Mixed-case: " + string.Join(", ", mixedCaseWords).TrimEnd(new char[] { ' ', ',' }));
            Console.WriteLine("Upper-case: " + string.Join(", ", upCaseWords).TrimEnd(new char[] { ' ', ',' }));
        }
    }
}
