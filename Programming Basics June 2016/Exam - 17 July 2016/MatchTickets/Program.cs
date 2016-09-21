using System;
//mathTickets
class MathTickets
{
    static void Main()
    {
        double budget = double.Parse(Console.ReadLine());
        string level = Console.ReadLine();
        int people = int.Parse(Console.ReadLine());

        double ticketBudget = 0;
        if (people >= 1 && people <=4)
        {
            ticketBudget = budget - (budget * 0.75);
        }
        else if (people >= 5 && people <= 9)
        {
            ticketBudget = budget - (budget * 0.6);
        }
        else if (people >= 10 && people <= 24)
        {
            ticketBudget = budget - (budget * 0.5);
        }
        else if (people >= 25 && people <= 49)
        {
            ticketBudget = budget - (budget * 0.4);
        }
        else if (people >= 50)
        {
            ticketBudget = budget - (budget * 0.25);
        }
        double ticketPrice = 0;
        if (level == "VIP")
        {
            ticketPrice = people * 499.99;
        }
        else if (level == "Normal")
        {
            ticketPrice = people * 249.99;
        }

        if (ticketBudget >= ticketPrice)
        {
            Console.WriteLine("Yes! You have {0:f2} leva left.",ticketBudget - ticketPrice);
        }
        else
        {
            Console.WriteLine("Not enough money! You need {0:f2} leva.",(ticketBudget - ticketPrice)* -1);
        }
    }
}
