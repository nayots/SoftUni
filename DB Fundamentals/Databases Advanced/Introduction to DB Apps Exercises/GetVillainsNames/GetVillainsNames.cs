using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace GetVillainsNames
{
    class GetVillainsNames
    {
        static void Main(string[] args)
        {
            SqlConnection connection = new SqlConnection(@"
                                    Server=.\SQLEXPRESS;" +
                        "Database=MinionsDB;" +
                        "Integrated Security=true");

            string query = File.ReadAllText(@"..\..\GetVillainsNames.sql");

            connection.Open();

            using (connection)
            {
                SqlCommand cmd = new SqlCommand(query, connection);

                SqlDataReader reader = cmd.ExecuteReader();

                using (reader)
                {
                    while (reader.Read())
                    {
                        Console.WriteLine("  Villain Name | Minions Count");
                        Console.WriteLine("---------------|---------------");
                        Console.WriteLine($"{reader[0], -14} | {reader[1],-14}");
                    }
                }
            }
        }
    }
}
