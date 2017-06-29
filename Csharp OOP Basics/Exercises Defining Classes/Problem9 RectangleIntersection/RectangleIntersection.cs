using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class RectangleIntersection
{
    private static void Main(string[] args)
    {
        var tokens = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();
        int n = tokens[0];
        int m = tokens[1];

        List<Rectangle> rectangles = new List<Rectangle>();

        for (int i = 0; i < n; i++)
        {
            var details = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var id = details[0];
            var w = double.Parse(details[1]);
            var h = double.Parse(details[2]);
            var x = double.Parse(details[3]);
            var y = double.Parse(details[4]);
            rectangles.Add(new Rectangle(id, w, h, x, y));
        }

        for (int j = 0; j < m; j++)
        {
            var ids = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            var rect1 = rectangles.First(x => x.ID == ids[0]);
            var rect2 = rectangles.First(x => x.ID == ids[1]);

            string res = rect1.IntersectsWith(rect2) ? "true" : "false";

            Console.WriteLine(res);
        }
    }
}