using System;
//Rectangle of N x N Stars
class RectangleNXNStars
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        for (int i = 0; i < n; i++)
        {
            Console.WriteLine(new string('*', n));
        }
    }
}
