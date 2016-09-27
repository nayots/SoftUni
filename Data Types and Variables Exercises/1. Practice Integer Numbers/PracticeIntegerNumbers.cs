using System;
//1.	Practice Integer Numbers
class PracticeIntegerNumbers
{
    static void Main()
    {
        sbyte firstNUmber = sbyte.Parse(Console.ReadLine());
        byte secondNumber = byte.Parse(Console.ReadLine());
        short thirdNumber = short.Parse(Console.ReadLine());
        ushort forthNumber = ushort.Parse(Console.ReadLine());
        uint fifthNumber = uint.Parse(Console.ReadLine());
        int sixtNumber = int.Parse(Console.ReadLine());
        long seventhNumber = long.Parse(Console.ReadLine());

        Console.WriteLine("{0}\n{1}\n{2}\n{3}\n{4}\n{5}\n{6}"
            , firstNUmber, secondNumber, thirdNumber, forthNumber, fifthNumber, sixtNumber, seventhNumber);
    }
}
