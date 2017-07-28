using InfernoInfinity.Interfaces;
using System;

namespace InfernoInfinity.Core
{
    public class OutputHandler : IOutputHandler
    {
        public void PrintLine(string line)
        {
            Console.WriteLine(line);
        }
    }
}