using System;
//Odd Even Sum
class OddEvenSum
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        int evenSum = 0;
        int oddSum = 0;
        for (int i = 0; i < n; i++)
        {
            if (i % 2 == 0)
            {
                evenSum += int.Parse(Console.ReadLine());
            }
            else
            {
                oddSum += int.Parse(Console.ReadLine());
            }
        }
        if (Math.Abs(evenSum - oddSum) == 0)
        {
            Console.WriteLine("Yes Sum = {0}", evenSum);
        }
        else
        {
            Console.WriteLine("No Diff = {0}", Math.Abs(evenSum - oddSum));
        }
    }
}
