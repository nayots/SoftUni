using System;
class Program
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        int counter = 1;
        int num = 1;

        while (num <= n)
        {
            for (int j = 0; j < counter; j++)
            {
                Console.Write("{0} ",num);
                num++;
                if (num > n)
                {
                    return;
                }
            }
            counter++;
            Console.WriteLine();
        }
    }
}
