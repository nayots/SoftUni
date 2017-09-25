using BankSystem.Client.Contracts;
using BankSystem.Data;
using System;

namespace BankSystem.Client.Core
{
    public class CommandInterpreter : ICommandInterpreter
    {
        private const string NameSpacePath = @"BankSystem.Client.Core.Commands.{0}Command";

        private BankSystemContext db;

        public CommandInterpreter(BankSystemContext db)
        {
            this.db = db;
        }

        public IExecutable InterpretCommand(string commandName, string[] arguments)
        {
            IExecutable command = null;

            string typeName = string.Format(NameSpacePath, commandName);

            Type classType = Type.GetType(typeName);

            if (classType != null)
            {
                command = (IExecutable)Activator.CreateInstance(classType, new object[] { db, arguments });
            }

            return command;
        }
    }
}