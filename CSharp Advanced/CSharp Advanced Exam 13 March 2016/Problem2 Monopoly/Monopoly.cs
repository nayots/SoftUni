using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem2_Monopoly
{
    class Monopoly
    {
        private static void Main(string[] args)
        {
            var dimensions = Console.ReadLine().Split().Select(int.Parse).ToArray();

            Queue<string> steps = new Queue<string>();

            int money = 50;
            int hotels = 0;
            int turns = 0;
            int stepCounter = 0;

            for (int i = 1; i <= dimensions[0]; i++)
            {
                var events = Console.ReadLine().ToCharArray();
                if (i % 2 == 0)
                {
                    Array.Reverse(events);
                }

                foreach (var ev in events)
                {
                    steps.Enqueue(ev.ToString());
                }
            }

            while (steps.Count > 0)
            {
                stepCounter++;
                var currentEvent = steps.Dequeue();

                switch (currentEvent)
                {
                    case "H":
                        hotels++;
                        Console.WriteLine($"Bought a hotel for {money}. Total hotels: {hotels}.");
                        money = 0;
                        break;

                    case "J":
                        Console.WriteLine($"Gone to jail at turn {turns}.");
                        for (int i = 0; i < 2; i++)
                        {
                            turns++;
                            money += ApplyEndOfTurnMechanics(hotels);
                        }
                        break;

                    case "F":
                        //NOTHING HAPPENS
                        break;

                    case "S":
                        int r = (int)(Math.Ceiling((double)stepCounter / dimensions[1]));
                        int c = stepCounter - ((r - 1) * dimensions[1]);

                        if (r % 2 == 0)
                        {
                            c = (dimensions[1] - c) + 1;
                        }

                        var price = r * c;
                        if (money >= price)
                        {
                            money -= price;
                            Console.WriteLine($"Spent {price} money at the shop.");
                        }
                        else
                        {
                            Console.WriteLine($"Spent {money} money at the shop.");
                            money = 0;
                        }
                        break;
                }
                turns++;
                money += ApplyEndOfTurnMechanics(hotels);
            }

            Console.WriteLine($"Turns {turns}");
            Console.WriteLine($"Money {money}");
        }

        private static int ApplyEndOfTurnMechanics(int hotels)
        {
            return hotels * 10;
        }
    }
}