using System;
//VegetableMarket
class VegetableMarket
{
    static void Main()
    {
        double vegPrice = double.Parse(Console.ReadLine());
        double fruitsPrice = double.Parse(Console.ReadLine());
        int vegQuantity = int.Parse(Console.ReadLine());
        int fruitsQuantity = int.Parse(Console.ReadLine());

        Console.WriteLine(((vegPrice * vegQuantity) + (fruitsPrice * fruitsQuantity))/ 1.94);
    }
}
