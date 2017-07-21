using CustomList.Core;

namespace CustomList
{
    class Startup
    {
        private static void Main(string[] args)
        {
            var ci = new CommandInterpreter();

            ci.ProcessInput();
        }
    }
}