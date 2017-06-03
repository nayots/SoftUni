using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem2_LineNumbers
{
    class LineNumbers
    {
        private static void Main(string[] args)
        {
            StreamReader reader = new StreamReader(@"..\..\sampleText.txt");
            StreamWriter writer = new StreamWriter(@"..\..\sampleTextEdited.txt");
            Console.WriteLine("Starting text editing...");
            using (reader)
            {
                using (writer)
                {
                    int lineNum = 1;
                    var line = reader.ReadLine();
                    while (line != null)
                    {
                        writer.WriteLine($"{lineNum}. " + line);
                        line = reader.ReadLine();
                        lineNum++;
                    }
                }
            }

            Console.WriteLine("Text editing finished.");
        }
    }
}