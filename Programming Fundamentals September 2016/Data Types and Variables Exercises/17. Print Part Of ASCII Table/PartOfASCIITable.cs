using System;
//17. Print Part Of ASCII Table
namespace PartOfASCIITable
{
    public class PartOfASCIITable
    {
        public static void Main()
        {
            int startChar = int.Parse(Console.ReadLine());
            int endChar = int.Parse(Console.ReadLine());

            for (int i = startChar; i <= endChar; i++)
            {
                Console.Write($"{(char)i} ");
            }
        }
    }
}
