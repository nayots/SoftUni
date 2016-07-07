using System;
//Cinema
class Cinema
{
    static void Main(string[] args)
    {
        string pricing = Console.ReadLine();
        int r = int.Parse(Console.ReadLine());
        int c = int.Parse(Console.ReadLine());

        switch (pricing)
        {
            case "Premiere":
                Console.WriteLine("{0:f2} leva",(r * c) * 12.00);
                break;
            case "Normal":
                Console.WriteLine("{0:f2} leva", (r * c) * 7.50);
                break;
            case "Discount":
                Console.WriteLine("{0:f2} leva", (r * c) * 5.00);
                break;
            default:
                break;
        }
    }
}
