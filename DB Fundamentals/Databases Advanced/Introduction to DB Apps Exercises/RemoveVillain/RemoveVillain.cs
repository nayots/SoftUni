using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace RemoveVillain
{
    class RemoveVillain
    {
        static void Main(string[] args)
        {
            int villainId = -1;

            Console.Write("Enter villain id: ");
            while (!int.TryParse(Console.ReadLine(), out villainId) || villainId < 1)
            {
                Console.Write("Enter a valid villain id: ");
            }

            SqlConnection connection = new SqlConnection(@"
                                    Server=.\SQLEXPRESS;" +
                                    "Database=MinionsDB;" +
                                    "Integrated Security=true");

            connection.Open();

            using (connection)
            {
                string checkVillainQuery = @"SELECT COUNT(*) FROM Villains WHERE Id = @VillainId";

                SqlCommand checkVillainCmd = new SqlCommand(checkVillainQuery, connection);
                checkVillainCmd.Parameters.Add(new SqlParameter("VillainId", villainId));

                
                if ((int)checkVillainCmd.ExecuteScalar() > 0)
                {
                    string freedonQuery = @"DELETE MinionsVillains WHERE VillainId = @VillainId";

                    SqlCommand freedomCmd = new SqlCommand(freedonQuery, connection);
                    freedomCmd.Parameters.Add(new SqlParameter("VillainId", villainId));

                    int freedMinions = (int)freedomCmd.ExecuteNonQuery();

                    string getVillainNameQ = @"SELECT Name FROM Villains WHERE Id = @VillainId";

                    SqlCommand getVillainNameCmd = new SqlCommand(getVillainNameQ, connection);
                    getVillainNameCmd.Parameters.Add(new SqlParameter("VillainId", villainId));

                    string villainName = getVillainNameCmd.ExecuteScalar().ToString();

                    string delVQ = @"DELETE FROM Villains WHERE Id = @VillainId";

                    SqlCommand deleteVillainCmd = new SqlCommand(delVQ, connection);
                    deleteVillainCmd.Parameters.Add(new SqlParameter("VillainId", villainId));
                    deleteVillainCmd.ExecuteNonQuery();


                    Console.WriteLine($"{villainName} was deleted\n{freedMinions} minions released.");
                }
                else
                {
                    Console.WriteLine("No such villain was found");
                }
            }
        }
    }
}
