using System;
using System.Collections.Generic;
using System.Linq;
//03. Odd Occurrences
namespace OddOccurrences
{
    class OddOccurrences
    {
        public static void Main(string[] args)
        {
            string[] inputWords = Console.ReadLine().ToLower().Split(' ');

            CountOddOccurences(inputWords);
        }

        private static void CountOddOccurences(string[] words)
        {
            Dictionary<string, int> entries = new Dictionary<string, int>();

            foreach (string w in words)
            {
                if (entries.ContainsKey(w))
                {
                    entries[w] += 1;
                }
                else
                {
                    entries.Add(w, 1);
                }
            }
            List<string> results = new List<string>();

            foreach (KeyValuePair<string,int> item in entries)
            {
                if (item.Value % 2 != 0)
                {
                    results.Add(item.Key);
                }
            }

            Console.WriteLine(string.Join(", ",results).TrimEnd(',',' '));
        }
    }
}
