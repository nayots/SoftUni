using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
//01. Odd Lines
namespace OddLines
{
    class OddLines
    {
        static void Main(string[] args)
        {
            string[] lines = File.ReadAllLines(@"input.txt");

            File.WriteAllLines(@"output.txt", lines.Where((line, index) => index % 2 == 1));
        }
    }
}
