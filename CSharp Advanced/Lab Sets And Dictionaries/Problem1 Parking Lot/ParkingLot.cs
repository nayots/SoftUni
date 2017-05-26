using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Problem1_Parking_Lot
{
    class ParkingLot
    {
        static void Main(string[] args)
        {
            var input = Console.ReadLine();

            var cars = new SortedSet<string>();

            while (input != "END")
            {
                var commandArgs = Regex.Split(input, ", ");
                if (commandArgs[0] == "IN")
                {
                    cars.Add(commandArgs[1]);
                }
                else
                {
                    cars.Remove(commandArgs[1]);
                }

                input = Console.ReadLine();
            }

            Console.WriteLine(cars.Count > 0 ? string.Join("\n", cars) : "Parking Lot is Empty");
        }
    }
}
