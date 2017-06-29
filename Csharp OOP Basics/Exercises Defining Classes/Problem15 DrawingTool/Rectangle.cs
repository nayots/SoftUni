using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem15_DrawingTool
{
    public class Rectangle : Square
    {
        private int x;

        public Rectangle(int x, int y) : base(y)
        {
            this.X = x;
        }

        public int X
        {
            get { return x; }
            set { x = value; }
        }

        public override void Draw()
        {
            Console.WriteLine("|" + new string('-', this.X) + "|");
            for (int i = 1; i < this.Y - 1; i++)
            {
                Console.WriteLine("|" + new string(' ', this.X) + "|");
            }
            if (this.Y > 1)
            {
                Console.WriteLine("|" + new string('-', this.X) + "|");
            }
        }
    }
}