using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem1_Vehicles.Models
{
    public class Truck : Vehicle
    {
        public Truck(double fuelQuantity, double fuelConsumption, double tankCapacity) : base(fuelQuantity, fuelConsumption + 1.6, tankCapacity)
        {
        }

        public override void Refuel(double liters)
        {
            base.Refuel(liters);
            this.FuelQuantity += (liters * 0.95);
        }
    }
}