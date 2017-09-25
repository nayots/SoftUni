using BankSystem.Client.Contracts;
using System;

namespace BankSystem.Client.Core
{
    public class ConsoleWriter : IWriter
    {
        public void WriteLine(string line)
        {
            Console.ForegroundColor = ConsoleColor.White;
            Console.WriteLine(line);
            Console.ForegroundColor = ConsoleColor.Gray;
        }
    }
}