using System;
//Division
class Division
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        double p1 = 0;
        double p2 = 0;
        double p3 = 0;
        for (int i = 0; i < n; i++)
        {
            int cn = int.Parse(Console.ReadLine());
            if (cn % 2 == 0)
            {
                p1++;
            }
            if (cn % 3 == 0)
            {
                p2++;
            }
            if (cn % 4 == 0)
            {
                p3++;
            }
        }
        Console.WriteLine("{0:f2}%\n{1:f2}%\n{2:f2}%",
            (p1 / n) * 100,
            (p2 / n) * 100,
            (p3 / n) * 100);
    }
}
