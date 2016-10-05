using System;
using System.Collections.Generic;
using System.Linq;
//03. Fold and Sum
namespace FoldAndSum
{
    public class FoldAndSum
    {
        static void Main(string[] args)
        {
            int[] array = Console.ReadLine().Split(' ')
                .Select(int.Parse)
                .ToArray();

            int[] firstPart = new int[array.Length / 4];
            int[] secondPart = new int[array.Length / 4];
            int[] thirdPart = new int[array.Length / 4];
            int[] forthPart = new int[array.Length / 4];

            int position = 0;
            int part = array.Length / 4;

            for (int i = position, j = 0; position < part; position++, j++)
            {
                firstPart[j] = array[position];
            }
            for (int i = position, j = 0; position < (part * 2); position++, j++)
            {
                secondPart[j] = array[position];
            }
            for (int i = position, j = 0; position < (part * 3); position++, j++)
            {
                thirdPart[j] = array[position];
            }
            for (int i = position, j = 0; position < (part * 4); position++, j++)
            {
                forthPart[j] = array[position];
            }

            Array.Reverse(firstPart);
            Array.Reverse(forthPart);

            List<int> resultsOne = new List<int>();

            resultsOne.AddRange(firstPart);
            resultsOne.AddRange(forthPart);

            List<int> resultsTwo = new List<int>();

            resultsTwo.AddRange(secondPart);
            resultsTwo.AddRange(thirdPart);

            List<int> finalRes = new List<int>();

            for (int i = 0; i < resultsOne.Count; i++)
            {
                finalRes.Add(resultsOne[i] + resultsTwo[i]);
            }

            Console.WriteLine(string.Join(" ",finalRes));
        }
    }
}
