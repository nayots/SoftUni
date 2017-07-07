using Problem1_Vehicles.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem1_Vehicles
{
    class Startup
    {
        private static void Main(string[] args)
        {
            var carInfo = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            Vehicle car = new Car(double.Parse(carInfo[1]), double.Parse(carInfo[2]), double.Parse(carInfo[3]));
            var truckInfo = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            Vehicle truck = new Truck(double.Parse(truckInfo[1]), double.Parse(truckInfo[2]), double.Parse(truckInfo[3]));

            var busInfo = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

            Vehicle bus = new Bus(double.Parse(busInfo[1]), double.Parse(busInfo[2]), double.Parse(busInfo[3]));

            List<Vehicle> vehicles = new List<Vehicle>();
            vehicles.Add(car);
            vehicles.Add(truck);
            vehicles.Add(bus);

            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                try
                {
                    var commandTokens = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
                    var currentVehicle = vehicles.FirstOrDefault(v => v.GetType().Name == commandTokens[1]);
                    var number = double.Parse(commandTokens[2]);
                    if (commandTokens[0] == "Drive")
                    {
                        currentVehicle.Drive(number);
                    }
                    else if (commandTokens[0] == "Refuel")
                    {
                        currentVehicle.Refuel(number);
                    }
                    else if (commandTokens[0] == "DriveEmpty")
                    {
                        //currentVehicle.GetType().GetMethod("DriveEmpty").Invoke(currentVehicle, new object[] { number });
                        (currentVehicle as Bus).DriveEmpty(number);
                    }
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
            }

            Console.WriteLine($"{car}\n{truck}\n{bus}");
        }
    }
}