using System;
//Trade Comissions
class TradeComissions
{
    static void Main(string[] args)
    {
        string town = Console.ReadLine().ToLower();
        double quantity = double.Parse(Console.ReadLine());
        double comission = -1;

        switch (town)
        {
            case "sofia":
                if (quantity >= 0 && quantity <= 500)
                {
                    comission = quantity * 0.05;
                }
                else if (quantity > 500 && quantity <= 1000)
                {
                    comission = quantity * 0.07;
                }
                else if (quantity > 1000 && quantity <= 10000)
                {
                    comission = quantity * 0.08;
                }
                else if (quantity > 10000)
                {
                    comission = quantity * 0.12;
                }
                break;
            case "varna":
                if (quantity >= 0 && quantity <= 500)
                {
                    comission = quantity * 0.045;
                }
                else if (quantity > 500 && quantity <= 1000)
                {
                    comission = quantity * 0.075;
                }
                else if (quantity > 1000 && quantity <= 10000)
                {
                    comission = quantity * 0.10;
                }
                else if (quantity > 10000)
                {
                    comission = quantity * 0.13;
                }
                break;
            case "plovdiv":
                if (quantity >= 0 && quantity <= 500)
                {
                    comission = quantity * 0.055;
                }
                else if (quantity > 500 && quantity <= 1000)
                {
                    comission = quantity * 0.08;
                }
                else if (quantity > 1000 && quantity <= 10000)
                {
                    comission = quantity * 0.12;
                }
                else if (quantity > 10000)
                {
                    comission = quantity * 0.145;
                }
                break;
            default:
                break;
        }
        if (comission >= 0)
        {
            Console.WriteLine("{0:f2}", comission);
        }
        else
        {
            Console.WriteLine("error");
        }
    }
}
