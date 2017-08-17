using System.Collections.Generic;

public abstract class Command : ICommand
{
    public Command(List<string> args, IManager manager)
    {
        Args = args;
        Manager = manager;
    }

    public IManager Manager { get; protected set; }

    protected List<string> Args { get; set; }

    public abstract string Execute();
}