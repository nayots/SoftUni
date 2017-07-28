using CustomAttribute.Attributes;
using System;
using System.Linq;

namespace CustomAttribute
{
    [InfoAttribute("Pesho", 3, "Used for C# OOP Advanced Course - Enumerations and Attributes.", "Pesho", "Svetlio")]
    class Startup
    {
        private static void Main(string[] args)
        {
            string input = string.Empty;

            var attr = (InfoAttribute)typeof(Startup).GetCustomAttributes(true).First();

            while ((input = Console.ReadLine()) != "END")
            {
                attr.PrintInfo(input);
            }
        }
    }
}