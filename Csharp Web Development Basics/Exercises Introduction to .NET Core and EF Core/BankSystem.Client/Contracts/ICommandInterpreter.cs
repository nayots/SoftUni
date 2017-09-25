namespace BankSystem.Client.Contracts
{
    public interface ICommandInterpreter
    {
        IExecutable InterpretCommand(string commandName, string[] arguments);
    }
}