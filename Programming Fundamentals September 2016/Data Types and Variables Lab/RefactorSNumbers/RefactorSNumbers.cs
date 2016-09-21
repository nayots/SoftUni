using System;
class RefactorSNumbers
{
    static void Main()
    {
        int n = int.Parse(Console.ReadLine());
        for (int i = 1; i <= n; i++)
        {
            int temporaryNumber = i;
            int sum = 0;
            while (temporaryNumber > 0)
            {
                sum += temporaryNumber % 10;
                temporaryNumber /=  10;
            }
            bool special = false;
            special = (sum == 5) || (sum == 7) || (sum == 11);
            Console.WriteLine($"{i} -> {special}");
            sum = 0;
        }
    }
}
