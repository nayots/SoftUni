using System;
using System.Collections.Generic;
using System.Linq;
//07. AndreyAndBilliard
namespace AndreyAndTheBilliard
{
    class AndreyAndTheBilliard
    {
        static void Main(string[] args)
        {
            Dictionary<string, decimal> shopItems = new Dictionary<string, decimal>();

            List<Customer> customers = new List<Customer>();

            shopItems = GetInventory(shopItems);
            customers = ServeCustomers(shopItems);

            PrintResults(customers);
        }

        private static void PrintResults(List<Customer> customers)
        {
            foreach (var customer in customers.OrderBy(x => x.Name))
            {
                Console.WriteLine($"{customer.Name}");
                foreach (var pur in customer.Purchases)
                {
                    Console.WriteLine($"-- {pur.Key} - {pur.Value}");
                }
                Console.WriteLine($"Bill: {customer.Bill:f2}");
            }
            decimal totalSum = customers.Select(x => x.Bill).Sum();
            Console.WriteLine($"Total bill: {totalSum:f2}");
        }

        private static List<Customer> ServeCustomers(Dictionary<string, decimal> shopItems)
        {

            string command = Console.ReadLine();
            List<Customer> customers = new List<Customer>();

            while (command != "end of clients")
            {
                string[] order = command.Split('-', ',');
                string name = order[0];
                string product = order[1];
                int quantity = int.Parse(order[2]);
                
                Dictionary<string, int> purchase = new Dictionary<string, int>() { { product, quantity } };

                if (shopItems.ContainsKey(product))
                {
                    bool hasAlreadyPurchased = false;
                    decimal bill = shopItems[product] * quantity;
                    foreach (var cust in customers)
                    {
                        if (cust.Name == name)
                        {
                            hasAlreadyPurchased = true;
                            cust.Bill += bill;
                            if (cust.Purchases.ContainsKey(product))
                            {
                                cust.Purchases[product] += quantity;
                            }
                            else
                            {
                                cust.Purchases.Add(product, quantity);
                            }
                            break;
                        }
                        
                    }
                    if (hasAlreadyPurchased == false)
                    {
                        Customer customer = new Customer() { Name = name, Purchases = purchase, Bill = bill };
                        customers.Add(customer);
                    }


                }
                command = Console.ReadLine();
            }
            return customers;
        }

        private static Dictionary<string, decimal> GetInventory(Dictionary<string, decimal> shopItems)
        {
            int n = int.Parse(Console.ReadLine());
            Dictionary<string, decimal> items = new Dictionary<string, decimal>();

            for (int i = 0; i < n; i++)
            {
                string[] itemInfo = Console.ReadLine().Split('-');
                string item = itemInfo[0];
                decimal price = decimal.Parse(itemInfo[1]);

                if (items.ContainsKey(item))
                {
                    items[item] = price;
                }
                else
                {
                    items.Add(item, price);
                }
            }

            return items;
        }
    }

    class Customer
    {
        public string Name { get; set; }
        public Dictionary<string, int> Purchases { get; set; }
        public decimal Bill { get; set; }
    }
}
