using System;
//Digits
class Digits
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int z = n;
        int thirdDig = 0;
        int secDig = 0;
        int firstDig = 0;

        thirdDig = z % 10;
        z /= 10;
        secDig = z % 10;
        z /= 10;
        firstDig = z % 10;

        int row = firstDig + secDig;
        int col = firstDig + thirdDig;

        for (int j = 0; j < row; j++)
        {
            for (int k = 0; k < col; k++)
            {
                if (n % 5 == 0)
                {
                    n -= firstDig;
                }
                else if (n % 3 == 0)
                {
                    n -= secDig;
                }
                else
                {
                    n += thirdDig;
                }
                Console.Write("{0} ", n);
            }
            Console.WriteLine();
        }
    }
}
