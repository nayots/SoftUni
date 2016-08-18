using System;
using System.Globalization;
class OnTime
{
    static void Main()
    {
        int examHours = int.Parse(Console.ReadLine());
        int examMinutes = int.Parse(Console.ReadLine());
        int studentArrivalHours = int.Parse(Console.ReadLine());
        int StudentArrivalMinutes = int.Parse(Console.ReadLine());

        string time = examHours.ToString("D2") + ":" + examMinutes.ToString("D2");
        string format = "HH:mm";

        DateTime examTime = DateTime.ParseExact(time, format, CultureInfo.InvariantCulture);
        time = studentArrivalHours.ToString("D2") + ":" + StudentArrivalMinutes.ToString("D2");
        DateTime studentTime = DateTime.ParseExact(time, format, CultureInfo.InvariantCulture);

        int difH = (examTime - studentTime).Hours;
        int difM = (examTime - studentTime).Minutes;

        if (studentTime > examTime && difH < 0 || difM < 0)//Late
        {
            Console.WriteLine("Late");
            if (difH < 0)
            {
                Console.WriteLine("{0}:{1:D2} hours after the start", Math.Abs(difH), Math.Abs(difM));
            }
            else
            {
                Console.WriteLine("{0} minutes after the start", Math.Abs(difM));
            }
        }
        else if ((studentTime < examTime && difM <= 30 && difH <= 0) || examTime == studentTime)//On Time
        {
            Console.WriteLine("On time");
            Console.WriteLine("{0} minutes before the start", Math.Abs(difM));
        }
        else//Early
        {
            Console.WriteLine("Early");
            if (difH > 0)
            {
                Console.WriteLine("{0}:{1:D2} hours before the start", Math.Abs(difH), Math.Abs(difM));
            }
            else
            {
                Console.WriteLine("{0:D2} minutes before the start", Math.Abs(difM));
            }
        }
    }
}
