using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace InitialSetup
{
    class InitialSetup
    {
        static void Main(string[] args)
        {
            SqlConnection connection = new SqlConnection(@"
                                    Server=.\SQLEXPRESS;" +
                                    "Database=master;" +
                                    "Integrated Security=true");


            string query = File.ReadAllText(@"..\..\InitialSetup.sql");
            connection.Open();

            using (connection)
            {
                Console.WriteLine("Using Connection and execuring query");

                SqlCommand cmdOne = new SqlCommand("CREATE DATABASE MinionsDB", connection);
                cmdOne.ExecuteNonQuery();
                Console.WriteLine("MinionsDB Database created");
                Console.WriteLine("Populating MinionsDB");
                SqlCommand cmdTwo = new SqlCommand(query, connection);

                int affectedRows = (int)cmdTwo.ExecuteNonQuery();
                Console.WriteLine($"Rows affected by query: {affectedRows}");
            }
            Console.WriteLine("No longer using connection");
        }
    }
}
