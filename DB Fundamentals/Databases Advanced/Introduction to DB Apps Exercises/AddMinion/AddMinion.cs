using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Data.SqlClient;
/*
 * In this exercise we add a new minion to a Villan that exist or we insert it(the villain) in the database. 
 * We asume that Minions with the same name are allowed(those minions are correctly inserted) like people in real life don't all have unique names.
 * The town is inserted if it does not exist but without a country since the exercise does not require it.
 * We check all the conditions needed before inserting to the DB as to avoid any errors.
 */
namespace AddMinion
{
    class AddMinion
    {
        static void Main(string[] args)
        {
            string minionName = string.Empty;
            int minionAge = 0;
            string minionTown = string.Empty;
            string villainName = string.Empty;

            while (minionName.Equals(string.Empty))
            {
                Console.Write("Enter minion name: ");
                minionName = Console.ReadLine().Trim();
            }

            //The user inputs an age and if it is correct it is parsed if not he is asked again until a valid input is entered.
            Console.Write("Enter minion age: ");
            while (!int.TryParse(Console.ReadLine(), out minionAge) || minionAge < 1)
            {
                Console.WriteLine("Age must be a positive number greather than 0 !");
                Console.Write("Enter minion age: ");
            }

            while (minionTown.Equals(string.Empty))
            {
                Console.Write("Enter a town name: ");
                minionTown = Console.ReadLine().Trim();
            }

            while (villainName.Equals(string.Empty))
            {
                Console.Write("Enter a villain name: ");
                villainName = Console.ReadLine().Trim();
            }

            bool townExists = false;

            bool villainExists = false;

            SqlConnection connection = new SqlConnection(@"
                                    Server=.\SQLEXPRESS;" +
            "Database=MinionsDB;" +
            "Integrated Security=true");

            connection.Open();
            using (connection)
            {
                string townCheckQuery = $@"SELECT COUNT(*) FROM Towns WHERE TownName = @MinionTown";

                SqlCommand cmdTown = new SqlCommand(townCheckQuery, connection);
                cmdTown.Parameters.Add(new SqlParameter("MinionTown",minionTown));

                if ((int)cmdTown.ExecuteScalar() > 0)
                {
                    townExists = true;
                }

                string villainCheckQuery = $@"SELECT COUNT(*) FROM Villains WHERE Name = @VillainName";

                SqlCommand cmdVillain = new SqlCommand(villainCheckQuery, connection);
                cmdVillain.Parameters.Add(new SqlParameter("VillainName", villainName));

                if ((int)cmdVillain.ExecuteScalar() > 0)
                {
                    villainExists = true;
                }

                //Its better if we also had the country but it is not included in this exercise. Here we add the town if it does not exist.
                if (!townExists)
                {
                    SqlCommand insertTown = new SqlCommand($@"INSERT Towns(TownName)VALUES(@MinionTown)", connection);
                    insertTown.Parameters.Add(new SqlParameter("MinionTown", minionTown));

                    insertTown.ExecuteNonQuery();
                    Console.WriteLine($"Town {minionTown} was added to the database.");
                }

                //Here we add the villain if he does not exist.
                if (!villainExists)
                {
                    SqlCommand insertVillain = new SqlCommand($@"INSERT Villains(Name, EvilnessFactor)VALUES(@VillainName, 'evil')", connection);
                    insertVillain.Parameters.Add(new SqlParameter("VillainName", villainName));

                    insertVillain.ExecuteNonQuery();
                    Console.WriteLine($"Villain {villainName} was added to the database.");
                }

                //We add the Minion
                SqlCommand insertMinion = new SqlCommand($@"INSERT Minions (Name,Age, TownId)
                SELECT @MinionName, @MinionAge, (SELECT TOP(1) Id FROM Towns WHERE TownName = @MinionTown ORDER BY id)", connection);
                insertMinion.Parameters.Add(new SqlParameter("MinionName", minionName));
                insertMinion.Parameters.Add(new SqlParameter("MinionAge", minionAge));
                insertMinion.Parameters.Add(new SqlParameter("MinionTown", minionTown));

                insertMinion.ExecuteNonQuery();

                //We connect the villain with his minion.
                SqlCommand insertInMtMTable = new SqlCommand($@"INSERT MinionsVillains(MinionId, VillainId)
                SELECT TOP (1) m.Id, v.Id FROM Minions AS m, Villains AS v WHERE m.Name = @MinionName AND v.Name = @VillainName ORDER BY m.Id DESC, v.Id DESC", connection);
                insertInMtMTable.Parameters.Add(new SqlParameter("MinionName", minionName));
                insertInMtMTable.Parameters.Add(new SqlParameter("VillainName", villainName));

                insertInMtMTable.ExecuteNonQuery();

                Console.WriteLine($"Successfully added {minionName} to be minion of {villainName}.");
            }

        }
    }
}
