using BankSystemDB.Models;
using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystemDB
{
    public class BankInitializer : CreateDatabaseIfNotExists<BankSystemDBContext>
    {
        protected override void Seed(BankSystemDBContext context)
        {
            SavingAccount sa1 = new SavingAccount()
            {
                AccountNumber = "ASAS3fa5arf5",
                Balance = 12000M,
                InterestRate = 0.1
            };
            SavingAccount sa2 = new SavingAccount()
            {
                AccountNumber = "ddasdsa56saf5",
                Balance = 600000M,
                InterestRate = 0.05
            };
            SavingAccount sa3 = new SavingAccount()
            {
                AccountNumber = "khujkgh86fh",
                Balance = 5000M,
                InterestRate = 0.15
            };

            CheckingAccount ca1 = new CheckingAccount()
            {
                AccountNumber = "adhifshj5js",
                Balance = 8000M,
                Fee = 0.5M
            };
            CheckingAccount ca2 = new CheckingAccount()
            {
                AccountNumber = "dasda5adsas",
                Balance = 6652M,
                Fee = 0.7M
            };
            CheckingAccount ca3 = new CheckingAccount()
            {
                AccountNumber = "wwwes5dzss",
                Balance =332000M,
                Fee = 1.5M
            };

            context.SavingAccounts.Add(sa1);
            context.SavingAccounts.Add(sa2);
            context.SavingAccounts.Add(sa3);

            context.CheckingAccounts.Add(ca1);
            context.CheckingAccounts.Add(ca2);
            context.CheckingAccounts.Add(ca3);
            context.SaveChanges();

            base.Seed(context);
        }
    }
}
