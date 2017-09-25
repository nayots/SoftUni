using StudentSystem.Client.Core;
using StudentSystem.Data;
using System;

namespace StudentSystem.Client
{
    class Program
    {
        private static void Main(string[] args)
        {
            using (var db = new StudentSystemContext())
            {
                Console.WriteLine("Preparing DB...");

                //db.Database.EnsureDeleted();
                //db.Database.EnsureCreated();

                Console.WriteLine("DB ready.");
            }

            var engine = new Engine();
            engine.Run();
        }
    }
}