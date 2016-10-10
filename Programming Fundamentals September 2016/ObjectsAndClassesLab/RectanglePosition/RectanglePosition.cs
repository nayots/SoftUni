using System;
using System.Collections.Generic;
using System.Linq;
//06. Rectangle Position
namespace RectanglePosition
{
    class RectanglePosition
    {
        static void Main(string[] args)
        {
            Rectangle rectOne = Rectangle.GetRectangle();
            Rectangle rectTwo = Rectangle.GetRectangle();

            if (rectOne.IsInside(rectTwo))
            {
                Console.WriteLine("Inside");
            }
            else
            {
                Console.WriteLine("Not inside");
            }
            
        }
    }

    class Rectangle
    {
        public int top { get; set; }
        public int left { get; set; }
        public int width { get; set; }
        public int height { get; set; }
        public int right
        {
            get
            {
                return left + width;
            }
        }
        public int bottom
        {
            get
            {
                return top + height;
            }
        }

        public bool IsInside(Rectangle r)
        {
            return (r.left <= left) && (r.right >= right) && (r.top <= top) && (r.bottom >= bottom);
        }

        public static Rectangle GetRectangle()
        {
            int[] rectValues = Console.ReadLine().Split().Select(int.Parse).ToArray();
            Rectangle rect = new Rectangle();
            rect.left = rectValues[0];
            rect.top = rectValues[1];
            rect.width = rectValues[2];
            rect.height = rectValues[3];


            return rect;
        }
    }
}
