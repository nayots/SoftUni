using System;
using System.Collections.Generic;
using System.Linq;
using System.IO;
//04. Merge Files
namespace MergeFiles
{
    class MergeFiles
    {
        static void Main(string[] args)
        {
            List<string> inputOne = File.ReadAllLines(@"FileOne.txt").ToList();
            List<string> inputTwo = File.ReadAllLines(@"FileTwo.txt").ToList();

            inputOne.AddRange(inputTwo);
            inputOne.Sort();

            File.AppendAllLines(@"output.txt", inputOne);
        }

    }
}
