using System;
//SumSeconds
class SumSeconds
{
    static void Main(string[] args)
    {
        int firstGuy = int.Parse(Console.ReadLine());
        int secondGuy = int.Parse(Console.ReadLine());
        int thirdGuy = int.Parse(Console.ReadLine());
        int combinedTime = firstGuy + secondGuy + thirdGuy;

        int minutes = combinedTime / 60;
        int seconds = combinedTime % 60;
        Console.WriteLine("{0}:{1:D2}", minutes, seconds);
    }
}
