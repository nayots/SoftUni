using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GringottsDB
{
    class GringottsDB
    {
        static void Main(string[] args)
        {
            //FirstLetter();
        }

        private static void FirstLetter()
        {
            using (var context = new GringottsContext())
            {
                var wizardLetters = context.WizzardDeposits
                    .Where(x => x.DepositGroup == "Troll Chest")
                    .Select(l => l.FirstName.Substring(0, 1))
                    .Distinct()
                    .OrderBy(z => z);

                Console.WriteLine(string.Join("\n", wizardLetters));
            }
        }
    }
}
