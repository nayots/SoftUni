using System;
//StopNumber
class StopNumber
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int m = int.Parse(Console.ReadLine());
        int s = int.Parse(Console.ReadLine());

        for (int i = m; i >= n; i--)
        {
            if (i % 2 == 0 && i % 3 == 0)
            {
                if (i != s)
                {
                    Console.Write("{0} ", i);
                }
                else
                {
                    return;
                }
            }
        }
    }
}