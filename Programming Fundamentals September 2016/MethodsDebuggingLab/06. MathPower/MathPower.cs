using System;
//06. Math Power
namespace _06.MathPower
{
    class MathPower
    {
        static void Main(string[] args)
        {
            double number = double.Parse(Console.ReadLine());
            double power = double.Parse(Console.ReadLine());
            Console.WriteLine($"{RaiseToPower(number, power)}");
        }

        static double RaiseToPower(double number, double power)
        {
            double RaisedToPower = Math.Pow(number, power);
            return RaisedToPower;
        }
    }
}
