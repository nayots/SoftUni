using BankSystem.Client.Contracts;
using BankSystem.Data;
using System;
using System.Linq;

namespace BankSystem.Client.Core
{
    public class Engine
    {
        public static bool UserIsLogged = false;
        public static int CurrentUserId = -1;
        public static string CurrentUserUsername;
        private BankSystemContext db;
        private ICommandInterpreter commandInterpreter;
        private IReader reader;
        private IWriter writer;

        public Engine(BankSystemContext db, ICommandInterpreter interpreter, IReader reader, IWriter writer)
        {
            this.db = db;
            this.commandInterpreter = interpreter;
            this.reader = reader;
            this.writer = writer;
        }

        public void Run()
        {
            while (true)
            {
                string input = this.reader.ReadLine();

                if (string.IsNullOrEmpty(input) || string.IsNullOrWhiteSpace(input))
                {
                    writer.WriteLine("Type end to exit.");
                    continue;
                }

                if (input.Trim().ToLower() == "end")
                {
                    Environment.Exit(0);
                }

                string[] tokens = SplitLine(input, ' ');

                string commandName = null;

                string[] arguments = null;

                if (tokens[0] == "Add" && tokens.Length > 1)
                {
                    commandName = tokens[0] + tokens[1];
                    arguments = tokens.Skip(2).ToArray();
                }
                else
                {
                    commandName = tokens[0];

                    arguments = tokens.Skip(1).ToArray();
                }

                var command = this.commandInterpreter.InterpretCommand(commandName, arguments);

                if (command == null)
                {
                    writer.WriteLine(string.Format(ErrorMessages.InvalidCommand, commandName));
                    continue;
                }

                string resultMessage = command.Execute();

                writer.WriteLine(resultMessage);
            }
        }

        private string[] SplitLine(string line, char ch)
        {
            var result = line.Split(new char[] { ch }, StringSplitOptions.RemoveEmptyEntries);

            return result;
        }

        private string[] SplitLine(string line, string str)
        {
            var result = line.Split(new string[] { str }, StringSplitOptions.RemoveEmptyEntries);

            return result;
        }
    }
}