using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem15_DrawingTool
{
    public class Square
    {
        private int y;

        public Square(int y)
        {
            this.Y = y;
        }

        public int Y
        {
            get { return y; }
            set { y = value; }
        }

        public virtual void Draw()
        {
            Console.WriteLine("|" + new string('-', y) + "|");
            for (int i = 1; i < y - 1; i++)
            {
                Console.WriteLine("|" + new string(' ', y) + "|");
            }
            if (y > 1)
            {
                Console.WriteLine("|" + new string('-', y) + "|");
            }
        }
    }
}