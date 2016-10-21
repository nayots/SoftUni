using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
//01. Sweet Dessert
namespace SweetDessert
{
    class SweetDessert
    {
        static void Main(string[] args)
        {
            decimal cash = decimal.Parse(Console.ReadLine());
            int guests = int.Parse(Console.ReadLine());
            decimal bananaPrice = decimal.Parse(Console.ReadLine());
            decimal eggPrice = decimal.Parse(Console.ReadLine());
            decimal berriesPrice = decimal.Parse(Console.ReadLine());

            int sets = (int)Math.Ceiling((double)guests / 6);

            //For a set of 6 she needs 2 bananas, 4 eggs and 0.2 kilos berries.

            decimal priceSum = sets * ((2 * bananaPrice) + (4 * eggPrice) + (0.2M * berriesPrice));

            if (priceSum <= cash)
            {
                Console.WriteLine($"Ivancho has enough money - it would cost {priceSum:f2}lv.");
            }
            else
            {
                decimal moneyToWithdraw = priceSum - cash;
                Console.WriteLine($"Ivancho will have to withdraw money - he will need {moneyToWithdraw:f2}lv more.");
            }
        }
    }
}
