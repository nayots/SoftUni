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
        }
    }
}
