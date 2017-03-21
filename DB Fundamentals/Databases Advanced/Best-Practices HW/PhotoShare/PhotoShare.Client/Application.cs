namespace PhotoShare.Client
{
    using Core;

    public class Application
    {
        public static void Main()
        {
            CommandDispatcher commandDispatcher = new CommandDispatcher();
            Engine engine = new Engine(commandDispatcher);
            engine.Run();

            //This solution contains problem 1 and 2 of the Best Practices HomeWork
            //Server is .\SQLEXPRESS
        }
    }
}
