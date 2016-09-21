using System;
//SleepyTomCat
class SleepyTomCat
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int playlimit = 30000;

        int minutes = ((365 - n) * 63) + (n * 127);

        if (minutes > 30000)
        {
            Console.WriteLine("Tom will run away");
            Console.WriteLine("{0} hours and {1} minutes more for play", (minutes - playlimit) / 60, (minutes - playlimit) % 60);
        }
        else
        {
            Console.WriteLine("Tom sleeps well");
            Console.WriteLine("{0} hours and {1} minutes less for play", (playlimit - minutes) / 60, (playlimit - minutes) % 60);
        }
    }
}
