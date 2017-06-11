using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem8_MultiplyBigNumber
{
    class MultiplyBigNumber
    {
        private static void Main(string[] args)
        {
            string firstNum = Console.ReadLine().TrimStart('0');
            string secNum = Console.ReadLine();
            if (firstNum == "0" || secNum == "0")
            {
                Console.WriteLine(0);
                return;
            }

            if (firstNum.Length < secNum.Length)
            {
                string temp = firstNum;
                firstNum = secNum;
                secNum = temp;
            }

            int inMind = 0;
            int remainder = 0;
            StringBuilder result = new StringBuilder();
            for (int i = firstNum.Length - 1; i >= 0; i--)
            {
                for (int j = secNum.Length - 1; j >= 0; j--)
                {
                    int sum = int.Parse(firstNum[i].ToString()) * int.Parse(secNum[j].ToString()) + inMind;
                    inMind = sum / 10;
                    remainder = sum % 10;
                    result.Insert(0, remainder.ToString());
                    if (i == 0 && inMind != 0)
                    {
                        result.Insert(0, inMind.ToString());
                    }
                }
            }

            Console.WriteLine(result);
        }
    }
}