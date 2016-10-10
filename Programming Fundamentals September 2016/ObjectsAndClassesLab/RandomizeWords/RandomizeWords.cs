using System;
using System.Collections.Generic;
using System.Linq;
//02. Randomize Words
namespace RandomizeWords
{
    class RandomizeWords
    {
        static void Main(string[] args)
        {
            string[] words = Console.ReadLine().Split();

            Random rnd = new Random();

            for (int i = 0; i < words.Length; i++)
            {
                int pos = rnd.Next(words.Length);
                string tempo = words[i];
                words[i] = words[pos];
                words[pos] = tempo;
            }

            foreach (string item in words)
            {
                Console.WriteLine(item);
            }
        }
    }
}
