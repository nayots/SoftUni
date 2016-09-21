using System;
//Half Sum Element
class HalfSumElement
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        int[] nArray = new int[n];
        int max = 0;
        int sum = 0;
        for (int i = 0; i < n; i++)
        {
            nArray[i] = int.Parse(Console.ReadLine());
            max = Math.Max(nArray[i], max);
            sum += nArray[i];
        }
        sum -= max;
        if (max == sum)
        {
            Console.WriteLine("Yes Sum = {0}", max);
        }
        else
        {
            Console.WriteLine("No Diff = {0}",Math.Abs(max - sum));
        }

    }
}
