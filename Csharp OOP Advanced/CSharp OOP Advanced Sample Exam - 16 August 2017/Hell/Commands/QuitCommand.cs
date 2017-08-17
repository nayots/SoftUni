using System.Collections.Generic;

public class QuitCommand : Command
{
    public QuitCommand(List<string> args, IManager manager) : base(args, manager)
    {
    }

    public override string Execute()
    {
        return base.Manager.Quit();
    }
}