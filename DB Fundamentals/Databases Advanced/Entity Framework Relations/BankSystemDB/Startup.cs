using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BankSystemDB
{
    class Startup
    {
        static void Main(string[] args)
        {
            //Exercise 11
            //Run the program to display results in the console for every problem in the exercise description.
            var context = new BankSystemDBContext();
            context.Database.Initialize(true);

            var sa1 = context.SavingAccounts.FirstOrDefault();
            var ca1 = context.CheckingAccounts.FirstOrDefault();

            Console.WriteLine("SAVINGS ACCOUNT");
            Console.WriteLine("Depositing money");
            Console.WriteLine($"Old balance {sa1.Balance:F2}");
            sa1.DepositMoney(10000M);
            context.SaveChanges();
            Console.WriteLine($"New balance {sa1.Balance:F2}\n");

            Console.WriteLine("Withdrawing money");
            Console.WriteLine($"Old balance {sa1.Balance:F2}");
            sa1.WithdrawMoney(2000M);
            context.SaveChanges();
            Console.WriteLine($"New balance {sa1.Balance:F2}\n");

            Console.WriteLine("Adding interest");
            Console.WriteLine($"Old balance {sa1.Balance:F2}");
            sa1.AddInterest();
            context.SaveChanges();
            Console.WriteLine($"New balance {sa1.Balance:F2}\n");

            Console.WriteLine("ChECKING ACCOUNT");
            Console.WriteLine("Depositing money");
            Console.WriteLine($"Old balance {ca1.Balance:F2}");
            ca1.DepositMoney(10000M);
            context.SaveChanges();
            Console.WriteLine($"New balance {ca1.Balance:F2}\n");

            Console.WriteLine("Withdrawing money");//This also deducts the fee.
            Console.WriteLine($"Old balance {ca1.Balance:F2}");
            ca1.WithdrawMoney(2000M);
            context.SaveChanges();
            Console.WriteLine($"New balance {ca1.Balance:F2}\n");

            Console.WriteLine("Just deducting fee");
            Console.WriteLine($"Old balance {ca1.Balance:F2}");
            ca1.DeductFee();
            context.SaveChanges();
            Console.WriteLine($"New balance {ca1.Balance:F2}\n");
        }
    }
}
