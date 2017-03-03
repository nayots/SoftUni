using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace IncreaseAgeStoredProc
{
    class IncreaseAgeStoredProc
    {
        static void Main(string[] args)
        {
            int minionId = -1;

            Console.Write("Enter minion id: ");
            while (!int.TryParse(Console.ReadLine(), out minionId) || minionId < 1)
            {
                Console.WriteLine("Id must be a positive number greather than 0 !");
                Console.Write("Enter minion Id: ");
            }


            SqlConnection connection = new SqlConnection(@"
                                    Server=.\SQLEXPRESS;" +
                        "Database=MinionsDB;" +
                        "Integrated Security=true");


            connection.Open();


            using (connection)
            {
                string query = @"EXEC udf_GetOlder @MinionId ";

                SqlCommand cmd = new SqlCommand(query, connection);

                cmd.Parameters.Add(new SqlParameter("MinionId", minionId));


                SqlDataReader reader = cmd.ExecuteReader();
                if (reader.Read())
                {
                    Console.WriteLine(" Minion name | Age ");
                    Console.WriteLine("-------------|-----");
                    Console.WriteLine($"{reader[0],12} |{reader[1],3}");
                }
                else
                {
                    Console.WriteLine($"No minion with id: {minionId} found.");
                }
            }
        }
    }
}
