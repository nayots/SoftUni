using Card_Problems.Core;

namespace Card_Problems
{
    class Startup
    {
        private static void Main(string[] args)
        {
            Engine engine = new Engine();

            engine.Run();
        }
    }
}