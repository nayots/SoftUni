using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
//2.Count substring occurrences
namespace CountSubstringOccurrences
{
    class CountSubstringOccurrences
    {
        static void Main(string[] args)
        {
            string inputText = Console.ReadLine().ToLower();
            string pattern = Console.ReadLine().ToLower();

            int counter = 0;
            int index = inputText.IndexOf(pattern);
            while (index != -1)
            {
                counter++;
                index = inputText.IndexOf(pattern, index+1);
            }

            Console.WriteLine(counter);
        }
    }
}
