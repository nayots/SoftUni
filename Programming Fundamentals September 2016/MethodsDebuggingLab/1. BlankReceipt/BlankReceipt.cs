using System;
//01. Blank Receipt
namespace BlankReceipt
{
    class BlankReceipt
    {
        static void PrintHeader()
        {
            Console.WriteLine("CASH RECEIPT");
            Console.WriteLine("------------------------------");
        }
        static void PrintReceipt()
        {
            Console.WriteLine("Charged to____________________");
            Console.WriteLine("Received by___________________");
        }
        static void PrintFooter()
        {
            Console.WriteLine("------------------------------");
            Console.WriteLine("\u00A9 SoftUni");
        }
        static void Main(string[] args)
        {
            PrintHeader();
            PrintReceipt();
            PrintFooter();
        }
    }
}
