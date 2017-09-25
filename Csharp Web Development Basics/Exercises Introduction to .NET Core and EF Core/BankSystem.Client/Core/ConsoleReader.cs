using BankSystem.Client.Contracts;
using System;

namespace BankSystem.Client.Core
{
    public class ConsoleReader : IReader
    {
        public string ReadLine()
        {
            string line = Console.ReadLine();

            return line;
        }
    }
}