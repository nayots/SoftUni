using System;
class DailyWinnings
{
    static void Main()
    {
        int days = int.Parse(Console.ReadLine());
        double moneyD = double.Parse(Console.ReadLine());
        double dollarValue = double.Parse(Console.ReadLine());

        double monthlySalary = moneyD * days;
        double yearlySalary = (monthlySalary * 12) + (monthlySalary * 2.5);
        yearlySalary *= 0.75;
        yearlySalary *= dollarValue;
        double dAverage = yearlySalary / 365;
        Console.WriteLine("{0:f2}",dAverage);
    }
}
