using System;
class Histogram
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        double p1 = 0;
        double p2 = 0;
        double p3 = 0;
        double p4 = 0;
        double p5 = 0;

        for (int i = 0; i < n; i++)
        {
            int num = int.Parse(Console.ReadLine());
            if (num < 200)
            {
                p1++;
            }
            else if (num >= 200 && num < 400)
            {
                p2++;
            }
            else if (num >= 400 && num < 600)
            {
                p3++;
            }
            else if (num >= 600 && num < 800)
            {
                p4++;
            }
            else if (num >= 800)
            {
                p5++;
            }
        }
        double divisor = p1 + p2 + p3 + p4 + p5;
        p1 = (p1 / divisor) * 100;
        p2 = (p2 / divisor) * 100;
        p3 = (p3 / divisor) * 100;
        p4 = (p4 / divisor) * 100;
        p5 = (p5 / divisor) * 100;

        Console.WriteLine("{0:f2}%", p1);
        Console.WriteLine("{0:f2}%", p2);
        Console.WriteLine("{0:f2}%", p3);
        Console.WriteLine("{0:f2}%", p4);
        Console.WriteLine("{0:f2}%", p5);
    }
}
