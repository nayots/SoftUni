using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem4_PascalTringle
{
    class PascalTringle
    {
        private static void Main(string[] args)
        {
            long n = long.Parse(Console.ReadLine());

            long[][] pascalTringleMatrix = new long[n][];

            pascalTringleMatrix[0] = new long[] { 1 };

            for (int i = 1; i < n; i++)
            {
                long[] currentArray = new long[i + 1];

                for (int j = 0; j < currentArray.Length; j++)
                {
                    long topLeft = 0;
                    long top = 0;
                    try
                    {
                        topLeft = pascalTringleMatrix[i - 1][j - 1];
                    }
                    catch (Exception)
                    {
                    }
                    try
                    {
                        top = pascalTringleMatrix[i - 1][j];
                    }
                    catch (Exception)
                    {
                    }
                    currentArray[j] = topLeft + top;
                }
                pascalTringleMatrix[i] = currentArray;
            }

            foreach (var array in pascalTringleMatrix)
            {
                Console.WriteLine(string.Join(" ", array));
            }
        }
    }
}