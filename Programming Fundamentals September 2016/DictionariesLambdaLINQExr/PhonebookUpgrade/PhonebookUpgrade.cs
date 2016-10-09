using System;
using System.Collections.Generic;
using System.Linq;
//02. Phonebook Upgrade
namespace PhonebookUpgrade
{
    public class PhonebookUpgrade
    {
        static void Main(string[] args)
        {
            SortedDictionary<string, string> phonebook = new SortedDictionary<string, string>();

            bool canContinue = true;

            while (canContinue)
            {
                string[] command = Console.ReadLine().Split();

                switch (command[0])
                {
                    case "A":
                        AddToPB(phonebook, command);
                        break;
                    case "S":
                        SearchPB(phonebook, command);
                        break;
                    case "ListAll":
                        ListAllEntries(phonebook);
                        break;
                    case "END":
                        canContinue = false;
                        break;
                }
            }
        }

        private static void ListAllEntries(SortedDictionary<string, string> phonebook)
        {
            foreach (KeyValuePair<string,string> entry in phonebook)
            {
                Console.WriteLine($"{entry.Key} -> {entry.Value}");
            }
        }

        private static void SearchPB(SortedDictionary<string, string> phonebook, string[] command)
        {
            if (phonebook.ContainsKey(command[1]))
            {
                Console.WriteLine("{0} -> {1}", command[1], phonebook[command[1]]);
            }
            else
            {
                Console.WriteLine($"Contact {command[1]} does not exist.");
            }
        }

        private static void AddToPB(SortedDictionary<string, string> phonebook, string[] command)
        {

            if (phonebook.ContainsKey(command[1]))
            {
                phonebook[command[1]] = command[2];
            }
            else
            {
                phonebook.Add(command[1], command[2]);
            }
        }
    }
}
