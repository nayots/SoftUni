using System;
//Christmas Tree
class ChristmasTree
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());

        for (int i = 0; i <= n; i++)
        {
            Console.WriteLine("{0}{1} | {1}{0}",new string(' ',n-i), new string('*',i));
        }
    }
}
