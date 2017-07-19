using Problem4_Telephony.Models;
using System;

namespace Problem4_Telephony
{
    class Startup
    {
        private static void Main(string[] args)
        {
            var numbers = Console.ReadLine().Split(new[] { ' ' });
            var urls = Console.ReadLine().Split(new[] { ' ' });

            Smartphone phone = new Smartphone(numbers, urls);

            Console.Write(phone.ToString());
        }
    }
}