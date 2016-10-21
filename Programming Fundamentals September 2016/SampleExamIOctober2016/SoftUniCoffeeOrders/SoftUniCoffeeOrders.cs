using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Globalization;
//01. Softuni Coffee Orders
namespace SoftUniCoffeeOrders
{
    class SoftUniCoffeeOrders
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());
            decimal totalSum = 0;
            for (int i = 0; i < n; i++)
            {
                decimal capsulePrice = decimal.Parse(Console.ReadLine());
                DateTime orderDate = DateTime.ParseExact(Console.ReadLine(), "d/M/yyyy", CultureInfo.InvariantCulture);
                long capsuleCount = long.Parse(Console.ReadLine());
                long daysInMonth = DateTime.DaysInMonth(orderDate.Year, orderDate.Month);
                //((daysInMonth * capsulesCount) * pricePerCapsule)
                decimal price = ((daysInMonth * capsuleCount) * capsulePrice);
                totalSum += price;

                Console.WriteLine($"The price for the coffee is: ${price:f2}");
            }
            Console.WriteLine($"Total: ${totalSum:f2}");
        }
    }
}
