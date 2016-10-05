using System;
using System.Collections.Generic;
using System.Linq;
//05. Short Words Sorted
namespace ShortWordsSorted
{
    class ShortWordsSorted
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine()
                .ToLower()
                .Split(new char[] { ' ', '.', ',', ':', ';', '(', ')', '[', ']', '"', '\'', '\\', '/', '!', '?' },StringSplitOptions.RemoveEmptyEntries)
                .ToArray();

            string[] shortWords = words
                .Where(s => s.Length < 5)
                .OrderBy(x => x)
                .Distinct()
                .ToArray();

            Console.WriteLine(string.Join(", ",shortWords));
        }
    }
}
