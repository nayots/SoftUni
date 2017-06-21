using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem3_NMS
{
    class NMS
    {
        private static void Main(string[] args)
        {
            List<string> words = new List<string>();

            var sb = new StringBuilder();

            var input = Console.ReadLine();
            while (input != "---NMS SEND---")
            {
                sb.Append(input);

                input = Console.ReadLine();
            }

            input = sb.ToString();

            while (input.Length > 0)
            {
                var inputLower = input.ToLower();
                var charCount = 1;
                if (inputLower.Length == 1)
                {
                    words.Add(input.Substring(0, charCount));
                    break;
                }

                for (int i = 0; i < inputLower.Length - 1; i++)
                {
                    if (inputLower[i] > inputLower[i + 1])
                    {
                        charCount = i + 1;
                        if (i == inputLower.Length - 1)
                        {
                            charCount++;
                        }
                        break;
                    }
                    else
                    {
                        charCount++;
                    }
                }
                words.Add(input.Substring(0, charCount));
                input = input.Substring(charCount);
            }

            var delimiter = Console.ReadLine();

            Console.WriteLine(string.Join(delimiter, words));
        }
    }
}