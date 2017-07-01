using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem1_ClassBox
{
    public class Box
    {
        private double length;
        private double width;
        private double height;

        public Box(double length, double width, double height)
        {
            this.Length = length;
            this.Width = width;
            this.Height = height;
        }

        private double Length
        {
            get
            {
                return this.length;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"Length cannot be zero or negative.");
                }
                this.length = value;
            }
        }

        private double Width
        {
            get
            {
                return this.width;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"Width cannot be zero or negative.");
                }
                this.width = value;
            }
        }

        private double Height
        {
            get
            {
                return this.height;
            }
            set
            {
                if (value <= 0)
                {
                    throw new ArgumentException($"Height cannot be zero or negative.");
                }
                this.height = value;
            }
        }

        public void PrintSurfaceArea()
        {
            double area = 2 * this.length * this.width + 2 * this.length * this.height + 2 * this.width * this.height;

            Console.WriteLine($"Surface Area - {area:F2}");
        }

        public void PrintLateralSurfaceArea()
        {
            double area = 2 * this.length * this.height + 2 * this.width * this.height;
            Console.WriteLine($"Lateral Surface Area - {area:F2}");
        }

        public void PrintVolume()
        {
            double volume = this.length * this.width * this.height;
            Console.WriteLine($"Volume - {volume:F2}");
        }
    }
}