using System;
using System.Numerics;
//10. Centuries to Nanoseconds
class CenturiesNanoseconds
{
    static void Main()
    {
        //years, days, hours, minutes, seconds, milliseconds, microseconds, nanoseconds.
        int centuries = int.Parse(Console.ReadLine());
        int years = centuries * 100;
        int days = (int)((double)years * 365.2422);
        int hours = days * 24;
        ulong minutes = (ulong)hours * 60;
        ulong seconds = (ulong)minutes * 60;
        ulong milliseconds = seconds * 1000;
        BigInteger microseconds = BigInteger.Multiply(milliseconds, 1000);
        BigInteger nanoseconds = BigInteger.Multiply(microseconds, 1000);

        Console.WriteLine($"{centuries} centuries = {years} years = {days} days = {hours} hours = {minutes} minutes = {seconds} seconds = {milliseconds} milliseconds = {microseconds} microseconds = {nanoseconds} nanoseconds");
    }
}
