namespace PhotoShare.Client.Core.Commands
{
    using System;

    public class ExitCommand
    {
        public string Execute()
        {
            Environment.Exit(0);
            return "Bye-bye!";
        }
    }
}
