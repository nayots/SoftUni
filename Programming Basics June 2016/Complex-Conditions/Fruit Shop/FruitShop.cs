using System;
//Fruit Shop
class FruitShop
{
    static void Main(string[] args)
    {
        string fruit = Console.ReadLine().ToLower();
        string day = Console.ReadLine().ToLower();
        double quantity = double.Parse(Console.ReadLine());
        double price = 0;

        if (day == "monday" || day == "tuesday" || day == "wednesday" || day == "thursday" || day == "friday")
        {
            switch (fruit)
            {
                case "banana":
                    price = 2.50;
                    Console.WriteLine("{0:f2}",quantity * price);
                    break;
                case "apple":
                    price = 1.20;
                    Console.WriteLine("{0:f2}",quantity * price);
                    break;
                case "orange":
                    price = 0.85;
                    Console.WriteLine("{0:f2}",quantity * price);
                    break;
                case "grapefruit":
                    price = 1.45;
                    Console.WriteLine("{0:f2}",quantity * price);
                    break;
                case "kiwi":
                    price = 2.70;
                    Console.WriteLine("{0:f2}",quantity * price);
                    break;
                case "pineapple":
                    price = 5.50;
                    Console.WriteLine("{0:f2}",quantity * price);
                    break;
                case "grapes":
                    price = 3.85;
                    Console.WriteLine("{0:f2}",quantity * price);
                    break;

                default:
                    Console.WriteLine("error");
                    break;
            }
        }
        else if (day == "saturday" || day == "sunday")
        {
            switch (fruit)
            {
                case "banana":
                    price = 2.70;
                    Console.WriteLine("{0:f2}",quantity * price);
                    break;
                case "apple":
                    price = 1.25;
                    Console.WriteLine("{0:f2}",quantity * price);
                    break;
                case "orange":
                    price = 0.90;
                    Console.WriteLine("{0:f2}",quantity * price);
                    break;
                case "grapefruit":
                    price = 1.60;
                    Console.WriteLine("{0:f2}",quantity * price);
                    break;
                case "kiwi":
                    price = 3.00;
                    Console.WriteLine("{0:f2}",quantity * price);
                    break;
                case "pineapple":
                    price = 5.60;
                    Console.WriteLine("{0:f2}",quantity * price);
                    break;
                case "grapes":
                    price = 4.20;
                    Console.WriteLine("{0:f2}",quantity * price);
                    break;

                default:
                    Console.WriteLine("error");
                    break;
            }
        }
        else
        {
            Console.WriteLine("error");
        }
    }
}
