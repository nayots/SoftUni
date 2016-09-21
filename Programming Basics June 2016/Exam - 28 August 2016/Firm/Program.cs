using System;
//Firm
class Firm
{
    static void Main()
    {
        int hoursNeeded = int.Parse(Console.ReadLine());
        double daysA = double.Parse(Console.ReadLine());
        int overtimeWorkers = int.Parse(Console.ReadLine());

        double workHours = Math.Floor((daysA * 0.9) * 8);
        double overtimeHours = overtimeWorkers * (daysA * 2);
        workHours += overtimeHours;

        if (workHours >= hoursNeeded)
        {
            Console.WriteLine("Yes!{0} hours left.",Math.Floor(workHours - hoursNeeded));
        }
        else
        {
            Console.WriteLine("Not enough time!{0} hours needed.",Math.Floor(hoursNeeded - workHours));
        }
    }
}
