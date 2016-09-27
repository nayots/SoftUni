using System;
//5. Boolean Variable
class BooleanVariable
{
    static void Main()
    {
        bool convertedBool = Convert.ToBoolean(Console.ReadLine());
        if (convertedBool)
        {
            Console.WriteLine("Yes");
        }
        else
        {
            Console.WriteLine("No");
        }
    }
}