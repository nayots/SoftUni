using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class InputScanner
{
    public void Run(List<BankAccount> accounts)
    {
        var input = Console.ReadLine();

        while (input != "End")
        {
            var tokens = input.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).ToArray();
            int id = int.Parse(tokens[1]);
            double amount;

            switch (tokens[0])
            {
                case "Create":
                    if (accounts.Any(a => a.ID == id))
                    {
                        Console.WriteLine($"Account already exists");
                    }
                    else
                    {
                        accounts.Add(new BankAccount(id));
                    }
                    break;

                case "Deposit":
                    amount = double.Parse(tokens[2]);
                    if (accounts.Any(a => a.ID == id))
                    {
                        var acc = accounts.First(x => x.ID == id);
                        acc.Balance += amount;
                    }
                    else
                    {
                        Console.WriteLine($"Account does not exist");
                    }
                    break;

                case "Withdraw":
                    amount = double.Parse(tokens[2]);
                    if (accounts.Any(a => a.ID == id))
                    {
                        var acc = accounts.First(x => x.ID == id);
                        if (acc.Balance - amount < 0)
                        {
                            Console.WriteLine("Insufficient balance");
                        }
                        else
                        {
                            acc.Balance -= amount;
                        }
                    }
                    else
                    {
                        Console.WriteLine($"Account does not exist");
                    }
                    break;

                case "Print":
                    if (accounts.Any(a => a.ID == id))
                    {
                        var acc = accounts.First(a => a.ID == id);
                        Console.WriteLine(acc.ToString());
                    }
                    else
                    {
                        Console.WriteLine($"Account does not exist");
                    }
                    break;
            }

            input = Console.ReadLine();
        }
    }
}