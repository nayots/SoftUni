using System;
//Small-Shop
class SmallShop
{
    static void Main(string[] args)
    {
        string product = Console.ReadLine();
        string town = Console.ReadLine();
        double amount = double.Parse(Console.ReadLine());
        double totalPrice = 0;
        if (town == "Sofia")
        {
            switch (product)
            {
                case "coffee":
                    totalPrice = amount * 0.50;
                    break;
                case "water":
                    totalPrice = amount * 0.80;
                    break;
                case "beer":
                    totalPrice = amount * 1.20;
                    break;
                case "sweets":
                    totalPrice = amount * 1.45;
                    break;
                case "peanuts":
                    totalPrice = amount * 1.60;
                    break;
            }
        }
        else if (town == "Plovdiv")
        {
            switch (product)
            {
                case "coffee":
                    totalPrice = amount * 0.40;
                    break;
                case "water":
                    totalPrice = amount * 0.70;
                    break;
                case "beer":
                    totalPrice = amount * 1.15;
                    break;
                case "sweets":
                    totalPrice = amount * 1.30;
                    break;
                case "peanuts":
                    totalPrice = amount * 1.50;
                    break;
            }
        }
        else if (town == "Varna")
        {
            switch (product)
            {
                case "coffee":
                    totalPrice = amount * 0.45;
                    break;
                case "water":
                    totalPrice = amount * 0.70;
                    break;
                case "beer":
                    totalPrice = amount * 1.10;
                    break;
                case "sweets":
                    totalPrice = amount * 1.35;
                    break;
                case "peanuts":
                    totalPrice = amount * 1.55;
                    break;
            }
        }
        Console.WriteLine(totalPrice);
    }
}
