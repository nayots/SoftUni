using System;
//Hospital
class Hospital
{
    static void Main()
    {
        int timeSpan = int.Parse(Console.ReadLine());
        int doctors = 7;
        int treated = 0;
        int unTreated = 0;
        for (int i = 1; i <= timeSpan; i++)
        {
            int dailyPatients = int.Parse(Console.ReadLine());
            if (i % 3 == 0 && unTreated > treated)
            {
                doctors++;
            }
            int patients = dailyPatients - doctors;
            if (patients > 0)
            {
                unTreated += patients;
                treated += doctors;
            }
            else if (patients <=0)
            {
                treated += patients + doctors;
            }
            
        }
        Console.WriteLine("Treated patients: {0}.",treated);
        Console.WriteLine("Untreated patients: {0}.",unTreated);
    }
}
