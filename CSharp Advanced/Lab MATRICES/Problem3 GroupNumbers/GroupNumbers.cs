using System;
using System.Linq;

namespace Problem3_GroupNumbers
{
    class GroupNumbers
    {
        private static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split(new[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(int.Parse).ToArray();

            int[][] matrix = new int[3][];

            var zeroRemainder = numbers.Where(n => Math.Abs(n) % 3 == 0).ToArray();
            matrix[0] = zeroRemainder;
            var oneRemainder = numbers.Where(n => Math.Abs(n) % 3 == 1).ToArray();
            matrix[1] = oneRemainder;
            var treeRemainder = numbers.Where(n => Math.Abs(n) % 3 == 2).ToArray();
            matrix[2] = treeRemainder;

            Console.WriteLine(string.Join(" ", matrix[0]));
            Console.WriteLine(string.Join(" ", matrix[1]));
            Console.WriteLine(string.Join(" ", matrix[2]));
        }
    }
}