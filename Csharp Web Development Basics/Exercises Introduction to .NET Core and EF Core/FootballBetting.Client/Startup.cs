using FootballBetting.Data;
using Microsoft.EntityFrameworkCore;

namespace FootballBetting.Client
{
    class Startup
    {
        private static void Main(string[] args)
        {
            //If you are nto using SQL EXPRESS , change the connection string in the DbContext

            System.Console.WriteLine("Working...");
            using (var db = new FootballBettingContext())
            {
                db.Database.Migrate();
            }
            System.Console.WriteLine("All done.");
        }
    }
}