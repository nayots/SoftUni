using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem1_OddLines
{
    class OddLines
    {
        private static void Main(string[] args)
        {
            StreamReader reader = new StreamReader(@"..\..\sampleText.txt");
            using (reader)
            {
                int lineCounter = 0;
                var line = reader.ReadLine();
                while (line != null)
                {
                    if (lineCounter < 2)
                    {
                        Console.WriteLine($"Line {lineCounter}: {line}");
                    }
                    else
                    {
                        if (lineCounter % 2 != 0)
                        {
                            Console.WriteLine($"Line {lineCounter}: {line}");
                        }
                    }
                    lineCounter++;
                    line = reader.ReadLine();
                }
            }
        }
    }
}