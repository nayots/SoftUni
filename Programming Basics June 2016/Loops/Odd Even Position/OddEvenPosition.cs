using System;
//Odd Even Position
class OddEvenPosition
{
    static void Main(string[] args)
    {
        double n = double.Parse(Console.ReadLine());
        //OddSum = x, OddMin = x, OddMax = x, EvenSum = x, EvenMin = x, EvenMax = x
        double oddSum = 0;
        double oddMin = 1000000000.0;
        double oddMax = -1000000000.0;
        double evenSum = 0;
        double evenMin = 1000000000.0;
        double evenMax = -1000000000.0;
        for (int i = 1; i <= n; i++)
        {
            double num = double.Parse(Console.ReadLine());
            if (i % 2 == 0)
            {
                evenSum += num;
                evenMin = Math.Min(evenMin, num);
                evenMax = Math.Max(evenMax, num);
            }
            else
            {
                oddSum += num;
                oddMin = Math.Min(oddMin, num);
                oddMax = Math.Max(oddMax, num);
            }
        }
        Console.WriteLine("OddSum={0}",oddSum);
        if (oddMin == 1000000000.0)
        {
            Console.WriteLine("OddMin=No");
        }
        else
        {
            Console.WriteLine("OddMin={0}",oddMin);
        }
        if (oddMax == -1000000000.0)
        {
            Console.WriteLine("OddMax=No");
        }
        else
        {
            Console.WriteLine("OddMax={0}", oddMax);
        }
        Console.WriteLine("EvenSum={0}", evenSum);
        if (evenMin == 1000000000.0)
        {
            Console.WriteLine("evenMin=No");
        }
        else
        {
            Console.WriteLine("evenMin={0}", evenMin);
        }
        if (evenMax == -1000000000.0)
        {
            Console.WriteLine("evenMax=No");
        }
        else
        {
            Console.WriteLine("evenMax={0}", evenMax);
        }
    }
}
