using System;
//EqualNumbers
class EqualNumbers
{
    static void Main(string[] args)
    {
        double numberOne = double.Parse(Console.ReadLine());
        double numberTwo = double.Parse(Console.ReadLine());
        double numberThree = double.Parse(Console.ReadLine());

        if (numberOne * 3 == numberOne + numberTwo + numberThree)
        {
            Console.WriteLine("yes");
        }
        else
        {
            Console.WriteLine("no");
        }
    }
}
