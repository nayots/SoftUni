using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem15_DrawingTool
{
    class DrawingTool
    {
        private static void Main(string[] args)
        {
            var shape = Console.ReadLine();
            var y = 0;
            var x = 0;

            Square sq = null;

            if (shape == "Square")
            {
                y = int.Parse(Console.ReadLine());
                sq = new Square(y);
            }
            else
            {
                y = int.Parse(Console.ReadLine());
                x = int.Parse(Console.ReadLine());
                sq = new Rectangle(y, x);
            }

            CorDraw cd = new CorDraw(sq);

            cd.Figure.Draw();
        }
    }
}