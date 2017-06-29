using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Car
{
    public Car(string model, double fuelAmount, double fuelCons)
    {
        this.Model = model;
        this.FuelAmount = fuelAmount;
        this.FuelConsumption = fuelCons;
        this.DistanceTraveled = 0;
    }

    public string Model { get; set; }
    public double FuelAmount { get; set; }
    public double FuelConsumption { get; set; }
    public long DistanceTraveled { get; set; }

    public void TryExecuteTrip(int kilometers)
    {
        double fuelNeeded = kilometers * FuelConsumption;

        if (this.FuelAmount - fuelNeeded >= 0D)
        {
            this.FuelAmount -= fuelNeeded;
            this.DistanceTraveled += kilometers;
        }
        else
        {
            Console.WriteLine("Insufficient fuel for the drive");
        }
    }
}