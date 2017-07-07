using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem1_Vehicles.Models
{
    public class Car : Vehicle
    {
        public Car(double fuelQuantity, double fuelConsumption, double tankCapacity) : base(fuelQuantity, fuelConsumption + 0.9, tankCapacity)
        {
        }

        public override void Refuel(double liters)
        {
            base.Refuel(liters);

            double freeSpace = this.TankCapacity - this.FuelQuantity;

            if (liters > freeSpace)
            {
                Console.WriteLine("Cannot fit fuel in tank");
                return;
            }

            this.FuelQuantity += liters;
        }
    }
}