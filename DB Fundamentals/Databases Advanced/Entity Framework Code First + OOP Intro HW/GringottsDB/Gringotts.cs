using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace GringottsDB
{
    class Gringotts
    {
        static void Main(string[] args)
        {
            //DB initialization
            //var context = new GringottsDBContext();
            //context.Database.Initialize(true);
            //AddWizardsSample();

        }

        private static void AddWizardsSample()
        {
            WizardDeposit dumbledore = new WizardDeposit()
            {
                FirstName = "Albus",
                LastName = "Dumblredore",
                Age = 150,
                MagicWandCreator = "Antioch Paverell",
                MagicWandSize = 15,
                DepositStartDate = new DateTime(2016, 10, 20),
                DepositExpirationDate = new DateTime(2020, 10, 20),
                DepositAmount = 20000.24M,
                DepositCharge = 0.2,
                IsDepositExpired = false
            };

            WizardDeposit harry = new WizardDeposit()
            {
                FirstName = "Harry",
                LastName = "Pooper",
                Age = 10,
                MagicWandCreator = "Made in china",
                MagicWandSize = 12,
                DepositStartDate = new DateTime(2016, 11, 21),
                DepositExpirationDate = new DateTime(2021, 11, 21),
                DepositAmount = 200000.24M,
                DepositCharge = 0.3,
                IsDepositExpired = false
            };

            WizardDeposit ron = new WizardDeposit()
            {
                FirstName = "Ron",
                LastName = "Swagpants",
                Age = 150,
                MagicWandCreator = "The Streets",
                MagicWandSize = 90,
                DepositStartDate = new DateTime(2011, 10, 20),
                DepositExpirationDate = new DateTime(2021, 10, 20),
                DepositAmount = 30000.24M,
                DepositCharge = 0.9,
                IsDepositExpired = false
            };

            var context = new GringottsDBContext();

            context.WizardDeposits.Add(dumbledore);
            context.WizardDeposits.Add(harry);
            context.WizardDeposits.Add(ron);

            context.SaveChanges();
        }
    }
}
