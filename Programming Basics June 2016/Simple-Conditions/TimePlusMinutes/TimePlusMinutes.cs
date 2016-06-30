using System;
using System.Globalization;
//TimePlusMinutes
class TimePlusMinutes
{
    static void Main(string[] args)
    {
        string format = "H:m";
        string hours = Console.ReadLine();
        string minutes = Console.ReadLine();
        string s = hours + ":" + minutes;

        DateTime userTime = DateTime.ParseExact(s, format,CultureInfo.InvariantCulture);

        userTime = userTime.AddMinutes(15);
        Console.WriteLine(userTime.ToString("H:mm"));
    }
}
