using System;
//PoolPipes
class PoolPipes
{
    static void Main()
    {
        int v = int.Parse(Console.ReadLine());
        int p1 = int.Parse(Console.ReadLine());
        int p2 = int.Parse(Console.ReadLine());
        double h = double.Parse(Console.ReadLine());

        double p1result = p1 * h;
        double p2result = p2 * h;
        double waterlevel = p1result + p2result;
        if (waterlevel <= v)
        {
            Console.WriteLine("The pool is {0}% full. Pipe 1: {1}%. Pipe 2: {2}%.",
                Math.Truncate((waterlevel / v) * 100), 
                Math.Truncate((p1result / waterlevel) * 100), 
                Math.Truncate((p2result / waterlevel) * 100));
        }
        else
        {
            Console.WriteLine("For {0} hours the pool overflows with {1} liters.",h,waterlevel - v);
        }
    }
}
