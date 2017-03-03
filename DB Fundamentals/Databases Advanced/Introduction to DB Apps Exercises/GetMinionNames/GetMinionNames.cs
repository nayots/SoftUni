using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.IO;

namespace GetMinionNames
{
    class GetMinionNames
    {
        static void Main(string[] args)
        {
            int VillainId = -1;
            Console.Write("Enter VillainId: ");
            while (!int.TryParse(Console.ReadLine(), out VillainId))
            {
                Console.WriteLine("You need to enter a valid Villain Id!");
                Console.Write("Enter VillainId: ");
            }



            SqlConnection connection = new SqlConnection(@"
                                    Server=.\SQLEXPRESS;" +
                        "Database=MinionsDB;" +
                        "Integrated Security=true");

            string query = File.ReadAllText(@"..\..\GetMinionNames.sql");

            connection.Open();
            using (connection)
            {
                SqlCommand cmd = new SqlCommand(query, connection);
                cmd.Parameters.Add(new SqlParameter("VillainId", VillainId));

                SqlDataReader reader = cmd.ExecuteReader();
                int counter = 1;

                if (!reader.Read())
                {
                    Console.WriteLine($"No villain with ID {VillainId} exists in the database");
                }
                else
                {
                    Console.WriteLine($"Villain: {reader[0]}");
                    if (reader[1].ToString() == "")
                    {
                        Console.WriteLine("(no minions)");
                    }
                    else
                    {
                        Console.WriteLine($"{counter,3}. {reader[1],-10} {reader[2],-10}");
                        counter++;
                    }

                    while (reader.Read())
                    {
                        Console.WriteLine($"{counter,3}. {reader[1],-10} {reader[2],-10}");
                        counter++;
                    }
                }
            }
        }
    }
}
