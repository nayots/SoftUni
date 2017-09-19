using Problem3StudentsAndCourses.Data;
using System;

namespace Problem3_StudentsAndCourses
{
    class Startup
    {
        private static void Main(string[] args)
        {
            using (var db = new SCContext())
            {
                Console.WriteLine("Preparing database...");

                db.Database.EnsureDeleted();
                db.Database.EnsureCreated();

                Console.WriteLine("Done");
            }
        }
    }
}