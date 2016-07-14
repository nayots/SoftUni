using System;
//Equal Pairs
class EqualPairs
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        int[] pairs = new int[n];
        int pairNumber = 0;
        for (int i = 1; i <= 2 * n; i++)
        {
            pairs[pairNumber] += int.Parse(Console.ReadLine());
            if (i % 2 == 0 && i != 2 * n)
            {
                pairNumber++;
            }
        }
        bool equal = false;
        int lastValue = pairs[0];
        int minValue = 100000000;
        int maxValue = -100000000;
        int maxdiff = 0;
        for (int i = 0; i < n; i++)
        {
            int diff = Math.Abs(lastValue - pairs[i]);
            if (diff > maxdiff && i != 0)
            {
                maxdiff = diff;
            }
            if (pairs[i] == lastValue)
            {
                equal = true;
                lastValue = pairs[i];
            }
            else
            {
                equal = false;
                lastValue = pairs[i];
            }
            if (pairs[i] > maxValue)
            {
                maxValue = pairs[i];
            }
            if (pairs[i] < minValue)
            {
                minValue = pairs[i];
            }

        }

        if (equal)
        {
            Console.WriteLine("Yes, value={0}", pairs[0]);
        }
        else
        {
            Console.WriteLine("No, maxdiff={0}", maxdiff);
        }
    }
}
