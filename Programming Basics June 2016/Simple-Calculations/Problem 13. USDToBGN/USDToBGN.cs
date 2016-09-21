using System;
//USDToBGN
class USDToBGN
{
    static void Main(string[] args)
    {
        double usd = double.Parse(Console.ReadLine());
        Console.WriteLine("{0} BGN", Math.Round(usd * 1.79549, 2));
    }
}
