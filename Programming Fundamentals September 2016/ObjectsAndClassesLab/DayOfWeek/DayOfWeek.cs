using System;
using System.Collections.Generic;
using System.Linq;
using System.Globalization;
//01. Day of Week
namespace DayOfWeek
{
    class DayOfWeek
    {
        static void Main(string[] args)
        {
            string input = Console.ReadLine();

            DateTime date = DateTime.ParseExact(input, "d-M-yyyy", CultureInfo.InvariantCulture);
            Console.WriteLine($"{date.DayOfWeek}");
        }
    }
}
