using System;
//07. Greater of Two Values
namespace _07.GreaterOfTwoValues
{
    class GreaterOfTwoValues
    {
        static void Main(string[] args)
        {
            string dataType = Console.ReadLine();
            switch (dataType)
            {
                case "int":
                    Console.WriteLine(GetMax(
                        int.Parse(Console.ReadLine()), 
                        int.Parse(Console.ReadLine())));
                    break;
                case "char":
                    Console.WriteLine(GetMax(
                        char.Parse(Console.ReadLine()), 
                        char.Parse(Console.ReadLine())));
                    break;
                case "string":
                    Console.WriteLine(GetMax(
                        Console.ReadLine(),
                        Console.ReadLine()));
                    break;
            }
        }
        static int GetMax(int first, int second)
        {
            if (first > second)
            {
                return first;
            }
            else
            {
                return second;
            }
        }
        static char GetMax(char first, char second)
        {
            if (first > second)
            {
                return first;
            }
            else
            {
                return second;
            }
        }
        static string GetMax(string first, string second)
        {
            if (first.CompareTo(second) > 0)
            {
                return first;
            }
            else
            {
                return second;
            }
        }
    }
}
