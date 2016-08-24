using System;
//Tiles
class Tiles
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        double wT = double.Parse(Console.ReadLine());
        double lT = double.Parse(Console.ReadLine());
        int mB = int.Parse(Console.ReadLine());
        int oB = int.Parse(Console.ReadLine());

        double tiles = (n * n - (mB * oB)) / (wT * lT);
        double timeNeeded = tiles * 0.2;

        Console.WriteLine(tiles);
        Console.WriteLine(timeNeeded);
    }
}
