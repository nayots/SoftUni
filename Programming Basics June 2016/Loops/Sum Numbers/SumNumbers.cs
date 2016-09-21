using System;
//Sum Numbers
class SumNumbers
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        int sum = 0;
        for (int i = 0; i < n; i++)
        {
            sum += int.Parse(Console.ReadLine());
        }
        Console.WriteLine(sum);
    }
}
