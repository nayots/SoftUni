using System;
//Point in the Figure
class PointInFigure
{
    static void Main(string[] args)
    {
        int h = int.Parse(Console.ReadLine());
        int y = int.Parse(Console.ReadLine());
        int x = int.Parse(Console.ReadLine());
        int x1 = 4 * h;
        int y1 = 1 * h;
        int x2 = 1 * h;
        int y2 = 2 * h;
        int x11 = 1 * h;
        int y11 = 0 * h;
        int x22 = 0 * h;
        int y22 = 3 * h;


        if ((x <= x1 && x >= x2 && y >= y1 && y <= y2) || (x <= x11 && x >= x22 && y >= y11 && y <= y22))
        {
            if (
                (((x == x1 || x == x2) && y >= y1 && y <= y2) || ((y == y1 || y == y2) && x <= x1 && x >= x2) || // Borders top rectangle
                ((x == x11 || x == x22) && y >= y11 && y <= y22) || ((y == y11 || y == y22) && x <= x11 && x >= x22))// Borders bottom rectangle
               )
            {
                if ((y > y1 && y < y2) && (x == x2 || x == x11)) //Shared line
                {
                    Console.WriteLine("inside");
                }
                else
                {
                    Console.WriteLine("border");
                }
            }
            else
            {
                Console.WriteLine("inside");
            }
        }
        else
        {
            Console.WriteLine("outside");
        }
    }
}
