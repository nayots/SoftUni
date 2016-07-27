using System;
class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());

        for (int row = 1; row <= n; row++)
        {
            int left = row;
            int right = n - 1;
            for (int col = 1; col <= n; col++)
            {
                if (left <= n)
                {
                    Console.Write("{0} ", left);
                    left++;
                }
                else
                {
                    Console.Write("{0} ", right);
                    right--;
                }

            }
            Console.WriteLine();
        }
    }
}
