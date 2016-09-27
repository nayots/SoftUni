using System;
//14. Integer to Hex and Binary
namespace IntegerToHexAndBinary
{
    public class IntegerToHexAndBinary
    {
        public static void Main(string[] args)
        {
            int decimalNumber = int.Parse(Console.ReadLine());
            string hexString = Convert.ToString(decimalNumber, 16).ToUpper();
            string binaryString = Convert.ToString(decimalNumber, 2).ToUpper();
            Console.WriteLine($"{hexString}\n{binaryString}");
        }
    }
}
