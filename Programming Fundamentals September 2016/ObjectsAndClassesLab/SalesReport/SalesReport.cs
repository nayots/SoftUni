using System;
using System.Collections.Generic;
using System.Linq;
//07. Sales Report
namespace SalesReport
{
    class SalesReport
    {
        static void Main(string[] args)
        {
            Sale[] sales = Sale.GetSales();
            string[] towns = sales.Select(x => x.town).Distinct().OrderBy(n => n).ToArray();

            foreach (string town in towns)
            {
                double sum = sales.Where(x => x.town == town).Select(z => z.price * z.quantity).Sum();
                Console.WriteLine($"{town} -> {sum:f2}");
            }
        }
    }

    class Sale//town, product, price, quantity
    {
        public string town { get; set; }
        public string product { get; set; }
        public double price { get; set; }
        public double quantity { get; set; }

        public static Sale[] GetSales()
        {
            int n = int.Parse(Console.ReadLine());
            Sale[] sales = new Sale[n];

            for (int i = 0; i < n; i++)
            {
                sales[i] = GetSale();
            }
            return sales;
        }

        public static Sale GetSale()//Sofia beer 1.20 160
        {
            string[] saleInfo = Console.ReadLine().Split();
            Sale sale = new Sale() { town = saleInfo[0], product = saleInfo[1], price = double.Parse(saleInfo[2]), quantity = double.Parse(saleInfo[3]) };
            return sale;
        }
    }
}
