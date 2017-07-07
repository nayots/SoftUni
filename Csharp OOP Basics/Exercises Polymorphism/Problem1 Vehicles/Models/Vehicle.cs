using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem1_Vehicles.Models
{
    public abstract class Vehicle
    {
        private double fuelQuantity;
        private double fuelConsumption;
        private double tankCapacity;

        public double TankCapacity
        {
            get { return this.tankCapacity; }
            protected set { this.tankCapacity = value; }
        }

        public Vehicle(double fuelQuantity, double fuelConsumption, double tankCapacity)
        {
            this.FuelQuantity = fuelQuantity;
            this.FuelConsumption = fuelConsumption;
            this.TankCapacity = tankCapacity;
        }

        public virtual double FuelConsumption
        {
            get { return this.fuelConsumption; }
            protected set { this.fuelConsumption = value; }
        }

        public double FuelQuantity
        {
            get { return this.fuelQuantity; }
            protected set
            {
                if (value <= 0)
                {
                    throw new ArgumentException("Fuel must be a positive number");
                }

                this.fuelQuantity = value;
            }
        }

        public virtual void Refuel(double liters)
        {
            if (liters <= 0)
            {
                throw new ArgumentException("Fuel must be a positive number");
            }
        }

        public virtual void Drive(double km)
        {
            var fuelNeeded = km * this.FuelConsumption;

            if (this.FuelQuantity - fuelNeeded < 0)
            {
                Console.WriteLine($"{this.GetType().Name} needs refueling");
                return;
            }

            this.FuelQuantity -= fuelNeeded;
            Console.WriteLine($"{this.GetType().Name} travelled {km} km");
        }

        public override string ToString()
        {
            return $"{this.GetType().Name}: {this.FuelQuantity:F2}";
        }
    }
}