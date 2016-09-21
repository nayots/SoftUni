using System;
//Problem 6: TriangleOf55Stars
class TriangleOf55Stars
{
    static void Main(string[] args)
    {
        for (int i = 1; i <= 10; i++)
        {
            string stars = new string('*', i);
            Console.WriteLine(stars);
        }
    }
}
