using System;
//HotelRooms
class HotelRooms
{
    static void Main()
    {
        string month = Console.ReadLine();
        int nights = int.Parse(Console.ReadLine());

        double apPrice = 0;
        double stPrice = 0;
        if (month == "May" || month == "October")
        {
            stPrice = 50 * nights;
            apPrice = 65 * nights;
            if (nights > 7 && nights <= 14)
            {
                stPrice *= 0.95;
            }
            else if (nights > 14)
            {
                stPrice *= 0.70;
            }
        }
        else if (month == "June" || month == "September")
        {
            stPrice = 75.20 * nights;
            apPrice = 68.70 * nights;
            if (nights > 14)
            {
                stPrice *= 0.80;
            }
        }
        else if (month == "July" || month == "August")
        {
            stPrice = 76 * nights;
            apPrice = 77 * nights;
        }

        if (nights > 14)
        {
            apPrice *= 0.90;
        }

        Console.WriteLine("Apartment: {0:f2} lv.",apPrice);
        Console.WriteLine("Studio: {0:f2} lv.",stPrice);
    }
}
