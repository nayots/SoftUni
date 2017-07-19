using Problem3_Ferrari.Interfaces;
using Problem3_Ferrari.Models;
using System;

namespace Problem3_Ferrari
{
    class Startup
    {
        private static void Main(string[] args)
        {
            ICar car = new Ferrari(Console.ReadLine());
            Console.WriteLine(car.ToString());

            string ferrariName = typeof(Ferrari).Name;
            string iCarInterfaceName = typeof(ICar).Name;

            bool isCreated = typeof(ICar).IsInterface;
            if (!isCreated)
            {
                throw new Exception("No interface ICar was created");
            }
        }
    }
}