using System;
//Triangle of Dollars
class TriangleOfDollards
{
    static void Main(string[] args)
    {
        int n = int.Parse(Console.ReadLine());
        string str = "$";

        for (int i = 0; i < n; i++)
        {
            Console.WriteLine(str);
            str += " $";
        }
    }
}
