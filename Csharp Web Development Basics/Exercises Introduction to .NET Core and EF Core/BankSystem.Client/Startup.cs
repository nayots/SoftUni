using BankSystem.Client.Core;
using BankSystem.Data;

namespace BankSystem.Client
{
    class Startup
    {
        private static void Main(string[] args)
        {
            //If you are nto using SQL EXPRESS , change the connection string in the DbContext
            using (var db = new BankSystemContext())
            {
                //db.Database.EnsureDeleted();
                db.Database.EnsureCreated();

                var engine = new Engine(db, new CommandInterpreter(db), new ConsoleReader(), new ConsoleWriter());

                engine.Run();
            }
        }
    }
}