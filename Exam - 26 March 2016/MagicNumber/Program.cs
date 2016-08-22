using System;
//MagicNumber
class MagicNumber
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        for (int i = 111111; i < 1000000; i++)
        {
            int num = 1;
            int z = i;
            while (z != 0)
            {
                int digit = z % 10;
                z /= 10;
                num *= digit;
            }
            if (num == n)
            {
                Console.Write("{0} ", i);
            }
        }
    }
}
