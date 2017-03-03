using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ChangeTownNamesCasing
{
    class ChangeTownNamesCasing
    {
        static void Main(string[] args)
        {
            string countryName = string.Empty;


            while (countryName.Equals(string.Empty))
            {
                Console.Write("Enter Country name: ");
                countryName = Console.ReadLine().Trim();
            }


            SqlConnection connection = new SqlConnection(@"
                                    Server=.\SQLEXPRESS;" +
"Database=MinionsDB;" +
"Integrated Security=true");

            connection.Open();

            using (connection)
            {
                string getTownNamesQuery = @"SELECT t.TownName FROM Towns AS t
                                             INNER JOIN Countries AS c
                                             ON c.Id = t.CountryId
                                             WHERE c.CountryName = @CountryName";
                SqlCommand getTownNamesCmd = new SqlCommand(getTownNamesQuery, connection);
                getTownNamesCmd.Parameters.Add(new SqlParameter("CountryName", countryName));

                SqlDataReader reader = getTownNamesCmd.ExecuteReader();

                List<string> townNamesToFormat = new List<string>();

                while (reader.Read())
                {
                    if (reader[0].ToString() != reader[0].ToString().ToUpper())
                    {
                        townNamesToFormat.Add("'" + reader[0].ToString() + "'");
                    }
                }

                if (townNamesToFormat.Count() == 0)
                {
                    Console.WriteLine("No town names were affected.");
                }
                else
                {
                    string updateTownNamesQuery = $@"UPDATE Towns
                                                  SET TownName = UPPER(TownName)
                                                  WHERE TownName IN ({string.Join(", ", townNamesToFormat)})";

                    SqlCommand updateTownNamesCmd = new SqlCommand(updateTownNamesQuery, connection);

                    reader.Close();

                    int affected = (int)updateTownNamesCmd.ExecuteNonQuery();

                    //This removes the ' that ware added earlier and changes the casing
                    var resultsList = townNamesToFormat.Select(x => x.Trim(new char[] { '\'' })).Select(c => c.ToUpper()).ToList();

                    Console.WriteLine($"{affected} town names ware affected.\n[{string.Join(", ", resultsList)}]");
                }
            }
        }
    }
}
