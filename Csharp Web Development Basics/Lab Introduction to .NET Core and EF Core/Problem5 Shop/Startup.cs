using Problem5Shop.Core;
using Problem5Shop.Data;

namespace Problem5_Shop
{
    class Startup
    {
        private static void Main(string[] args)
        {
            using (var db = new ShopDbContext())
            {
                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();
            }

            var engine = new Engine();

            engine.Run();
        }
    }
}