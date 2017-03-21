namespace PhotoShare.Client.Core.Commands
{
    using System;

    public class ExitCommand
    {
        public void Execute()
        {
            Console.WriteLine("Good Bye!");
            Environment.Exit(0);
        }
    }
}
