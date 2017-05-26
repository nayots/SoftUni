using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem2_SoftUni_Party
{
    class SoftUniParty
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            var guests = new HashSet<string>();

            while (input != "PARTY")
            {
                guests.Add(input);

                input = Console.ReadLine();
            }

            while (input != "END")
            {
                guests.Remove(input);
                input = Console.ReadLine();
            }

            Console.WriteLine(guests.Count);
            Console.WriteLine(string.Join("\n", guests.OrderBy(x => x)));
        }
    }
}
