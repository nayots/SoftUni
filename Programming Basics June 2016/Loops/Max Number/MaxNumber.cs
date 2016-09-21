using System;
//Max Number
class MaxNumber
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        int max = 0;
        for (int i = 0; i < n; i++)
        {
            int num = int.Parse(Console.ReadLine());
            if (num > max)
            {
                max = num;
            }
            if (i == 0)
            {
                max = num;
            }
        }
        Console.WriteLine(max);
    }
}
