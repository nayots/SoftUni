using System;
//Volleyball
class Volleyball
{
    static void Main(string[] args)
    {
        string year = Console.ReadLine();
        int p = int.Parse(Console.ReadLine());
        int homeVisits = int.Parse(Console.ReadLine());
        double weekends = 48 - homeVisits;

        double volleyballDays = weekends * 0.75;
        volleyballDays = volleyballDays + homeVisits;
        double holydays = p * (2.0/3);
        volleyballDays = volleyballDays + holydays;
        if (year == "leap")
        {
            volleyballDays = volleyballDays * 1.15;
        }
        Console.WriteLine(Math.Truncate(volleyballDays));
    }
}
