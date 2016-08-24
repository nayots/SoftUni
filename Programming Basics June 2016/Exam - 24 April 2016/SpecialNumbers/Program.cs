using System;
//SpecialNumbers
class SpecialNumbers
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        for (int i = 1111; i <= 9999; i++)
        {
            bool special = true;
            int cNumber = i;
            for (int j = 0; j < 4; j++)
            {
                int cDigit = cNumber % 10;
                cNumber /= 10;
                if (cDigit == 0)
                {
                    special = false;
                    break;
                }
                if (n % cDigit != 0)
                {
                    special = false;
                }
            }
            if (special == true)
            {
                Console.Write("{0} ", i);
            }
        }
    }
}
