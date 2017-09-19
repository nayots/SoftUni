using Problem23EmployeesRelations.Data;

namespace Problem2_3_EmployeesRelations
{
    class Startup
    {
        private static void Main(string[] args)
        {
            using (var db = new EmpContext())
            {
                System.Console.WriteLine("Preparing database");

                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();

                System.Console.WriteLine("Done.");
            }
        }
    }
}