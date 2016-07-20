using System;
//Rectangle of 10 x 10 Stars
class RectangleTenXTenStars
{
    static void Main(string[] args)
    {
        for (int i = 0; i < 10; i++)
        {
            Console.WriteLine(new string('*',10));
        }
    }
}
