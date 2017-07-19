using Problem10_ExplicitInterfaces.Core;
using Problem10_ExplicitInterfaces.Interfaces;

namespace Problem10_ExplicitInterfaces
{
    class Startup
    {
        private static void Main(string[] args)
        {
            IEngine engine = new Engine();
            engine.Run();
        }
    }
}