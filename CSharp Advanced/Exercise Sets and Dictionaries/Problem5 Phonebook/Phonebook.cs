using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem5_Phonebook
{
    class Phonebook
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> phonebook = new Dictionary<string, string>();

            var input = Console.ReadLine();

            while (input != "search")
            {
                var inputArgs = input.Split('-');

                AddToPB(phonebook, inputArgs);

                input = Console.ReadLine();
            }

            input = Console.ReadLine();

            while (input != "stop")
            {
                SearchPB(phonebook, input);

                input = Console.ReadLine();
            }
        }

        private static void SearchPB(Dictionary<string, string> phonebook, string name)
        {
            if (phonebook.ContainsKey(name))
            {
                Console.WriteLine("{0} -> {1}", name, phonebook[name]);
            }
            else
            {
                Console.WriteLine($"Contact {name} does not exist.");
            }
        }

        private static void AddToPB(Dictionary<string, string> phonebook, string[] args)
        {

            if (phonebook.ContainsKey(args[0]))
            {
                phonebook[args[0]] = args[1];
            }
            else
            {
                phonebook.Add(args[0], args[1]);
            }
        }
    }
}
