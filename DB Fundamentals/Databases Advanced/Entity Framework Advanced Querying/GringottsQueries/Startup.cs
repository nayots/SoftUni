using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GringottsQueries
{
    class Startup
    {
        static void Main(string[] args)
        {
            var context = new GringottsContext();

            //connection string used is .\SQLEXPRESS you can change it in the App.config if you need to.

            //19.Deposits Sum for Ollivander Family
            //DepositGroups(context);

            //20.Deposits Filter
            //DepositFilter(context);
        }

        private static void DepositFilter(GringottsContext context)
        {
            string wandcrafter = "Ollivander family";

            var depositGroups = context.WizzardDeposits
                .Where(w => w.MagicWandCreator == wandcrafter)
                .GroupBy(g => g.DepositGroup)
                .Select(s => new { Name = s.Key, DepositsAmount = s.Sum(z => z.DepositAmount) })
                .Where(a => a.DepositsAmount < 150000)
                .OrderByDescending(d => d.DepositsAmount)
                .ToList();

            foreach (var depGroup in depositGroups)
            {
                Console.WriteLine($"{depGroup.Name} - {depGroup.DepositsAmount:F2}");
            }
        }

        private static void DepositGroups(GringottsContext context)
        {
            string wandcrafter = "Ollivander family";

            var depositGroups = context.WizzardDeposits
                .Where(w => w.MagicWandCreator == wandcrafter)
                .GroupBy(g => g.DepositGroup)
                .Select(s => new { Name = s.Key, DepositsAmount = s.Sum(z => z.DepositAmount) })
                .ToList();

            foreach (var depGroup in depositGroups)
            {
                Console.WriteLine($"{depGroup.Name} - {depGroup.DepositsAmount:F2}");
            }
        }
    }
}
