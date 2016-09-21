using System;
//GreaterNumber
class GreaterNumber
{
    static void Main(string[] args)
    {
        double firstNumber = double.Parse(Console.ReadLine());
        double secondNumber = double.Parse(Console.ReadLine());
        if (firstNumber > secondNumber)
        {
            Console.WriteLine(firstNumber);
        }
        else
        {
            Console.WriteLine(secondNumber);
        }
    }
}
