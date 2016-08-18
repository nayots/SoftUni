using System;
class TransportPrice
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        string timeOfDay = Console.ReadLine();
        
        double taxiKmPrice = 0.79;
        if (timeOfDay == "night")
        {
            taxiKmPrice = 0.9;
        }
        double taxiPrice = 0;
        double busPrice = 0;
        double trainPrice = 0;

        if (n < 20)
        {
            taxiPrice = taxiKmPrice * n + 0.70;
            Console.WriteLine(taxiPrice);
        }
        else if (n >= 20 && n < 100 )
        {
            busPrice = n * 0.09;
            Console.WriteLine(busPrice);
        }
        else if (n >= 100)
        {
            trainPrice = n * 0.06;
            Console.WriteLine(trainPrice);
        }
    }
}
