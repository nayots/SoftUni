using Problem4_Froggy.Models;
using System;
using System.Linq;

namespace Problem4_Froggy
{
    class Startup
    {
        private static void Main(string[] args)
        {
            var stones = Console.ReadLine().Split(new[] { ' ', ',' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse);

            Lake lake = new Lake(stones);

            Console.WriteLine(string.Join(", ", lake));
        }
    }
}