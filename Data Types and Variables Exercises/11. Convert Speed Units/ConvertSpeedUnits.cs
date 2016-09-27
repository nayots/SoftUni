using System;
//11. Convert Speed Units
class ConvertSpeedUnits
{
    static void Main()
    {
        int distanceM = int.Parse(Console.ReadLine());
        int hours = int.Parse(Console.ReadLine());
        int minutes = int.Parse(Console.ReadLine());
        int seconds = int.Parse(Console.ReadLine());
        int secondsConverted = (((hours * 60) * 60) + minutes * 60 + seconds);
        float mPs = ((float)distanceM / (float)secondsConverted);
        double hoursConverted = (hours + ((double)minutes / 60) + ((double)((double)seconds / 60) / 60));
        float kmH = (((float)distanceM / 1000) / (float)hoursConverted);
        float mpH = (float)((double)distanceM / (double)1609) / (float)hoursConverted;

        Console.WriteLine($"{mPs}\n{kmH}\n{mpH}");
    }
}
