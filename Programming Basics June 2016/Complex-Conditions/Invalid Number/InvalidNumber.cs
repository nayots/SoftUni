using System;
//Invalid Number
class InvalidNumber
{
    static void Main(string[] args)
    {
        double userNumber = double.Parse(Console.ReadLine());
        if (userNumber >=100 && userNumber <= 200 || userNumber == 0)
        {

        }
        else
        {
            Console.WriteLine("invalid");
        }
    }
}
