using System;
using System.Collections.Generic;
using System.Linq;
//01. Thea the Photographer
namespace TheaThePhotographer
{
    class TheaThePhotographer
    {
        static void Main(string[] args)
        {
            long n = long.Parse(Console.ReadLine());
            long filterTime = long.Parse(Console.ReadLine());
            double filterFactor = double.Parse(Console.ReadLine()) / 100;
            long uploadTime = long.Parse(Console.ReadLine());

            long totalTime = n * filterTime;
            long goodPictures = (long)(Math.Ceiling(n * filterFactor));
            totalTime += goodPictures * uploadTime;

            TimeSpan projectTime = TimeSpan.FromSeconds(totalTime);

            Console.WriteLine("{0:D1}:{1:D2}:{2:D2}:{3:D2}",
                projectTime.Days,
                projectTime.Hours,
                projectTime.Minutes,
                projectTime.Seconds);
        }
    }
}
