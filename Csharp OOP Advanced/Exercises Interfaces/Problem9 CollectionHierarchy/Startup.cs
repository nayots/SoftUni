using Problem9_CollectionHierarchy.Core;
using Problem9_CollectionHierarchy.Interfaces;

namespace Problem9_CollectionHierarchy
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