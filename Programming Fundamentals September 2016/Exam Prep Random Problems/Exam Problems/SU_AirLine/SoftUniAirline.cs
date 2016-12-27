using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Numerics;

namespace SU_AirLine
{
    class SoftUniAirLine
    {
        static void Main(string[] args)
        {
            int n = int.Parse(Console.ReadLine());

            decimal overallProfit = 0;

            List<decimal> flightProfits = new List<decimal>();

            for (int i = 0; i < n; i++)
            {
                decimal adultPassengers = decimal.Parse(Console.ReadLine()); //•	adult passengers count
                decimal adultTicketPrice = decimal.Parse(Console.ReadLine()); //•	adult ticket price
                decimal youthPassengers = decimal.Parse(Console.ReadLine()); //•	youth passengers count
                decimal youthTicketPrice = decimal.Parse(Console.ReadLine()); //•	youth ticket price
                decimal fuelPrice = decimal.Parse(Console.ReadLine()); //•	fuel price per hour
                decimal fuelConsumption = decimal.Parse(Console.ReadLine()); //•	fuel consumption per hour
                decimal flightDuration = decimal.Parse(Console.ReadLine()); //•	flight duration


                //(adult passengers count * adult ticket price) + (youth passengers count * youth ticket price)
                decimal flightIncome = (adultPassengers * adultTicketPrice) + (youthPassengers * youthTicketPrice);

                //flight duration * fuel consumption * fuel price
                decimal flightExpenses = flightDuration * fuelConsumption * fuelPrice;


                decimal profit = flightIncome - flightExpenses;

                if (flightIncome >= flightExpenses)
                {

                    Console.WriteLine($"You are ahead with {profit:F3}$.");
                }
                else
                {
                    Console.WriteLine($"We've got to sell more tickets! We've lost {profit:F3}$.");
                }

                overallProfit += profit;

                flightProfits.Add(profit);
            }

            //Overall profit -> {overallProfit}$.
            //Average profit -> {averageProfit}$.

            decimal averageProfit = flightProfits.Average();

            Console.WriteLine($"Overall profit -> {overallProfit:F3}$.");
            Console.WriteLine($"Average profit -> {averageProfit:F3}$.");
        }
    }
}
