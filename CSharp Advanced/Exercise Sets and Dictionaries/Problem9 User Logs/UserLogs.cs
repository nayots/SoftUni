using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem9_User_Logs
{
    class UserLogs
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, Dictionary<string, int>> users = new SortedDictionary<string, Dictionary<string, int>>();

            string command = Console.ReadLine();

            while (command != "end")
            {
                ProcessAndSaveData(command, users);
                command = Console.ReadLine();
            }

            PrintResultsData(users);
        }

        private static void PrintResultsData(SortedDictionary<string, Dictionary<string, int>> users)
        {
            foreach (KeyValuePair<string, Dictionary<string, int>> usr in users)
            {
                Console.WriteLine($"{usr.Key}:");
                int counter = 0;
                foreach (var item in usr.Value)
                {
                    Console.Write($"{item.Key} => {item.Value}");
                    if (counter < usr.Value.Count - 1)
                    {
                        Console.Write(", ");
                        counter++;
                    }
                    else
                    {
                        Console.WriteLine(".");
                    }
                }
            }
        }

        private static void ProcessAndSaveData(string command, SortedDictionary<string, Dictionary<string, int>> users)
        {
            List<string> lineData = command.Split(' ').ToList();
            string userName = lineData[2].Substring(5);
            string iP = lineData[0].Substring(3);

            if (users.ContainsKey(userName))
            {
                if (users[userName].ContainsKey(iP))
                {
                    users[userName][iP] += 1;
                }
                else
                {
                    users[userName].Add(iP, 1);
                }
            }
            else
            {
                users.Add(userName, new Dictionary<string, int> { { iP, 1 } });
            }
        }
    }
}
