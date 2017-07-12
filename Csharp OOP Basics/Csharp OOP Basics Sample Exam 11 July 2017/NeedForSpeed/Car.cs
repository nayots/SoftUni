using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public abstract class Car
{
    private string brand;
    private string model;
    private int yearOfProduction;
    private int horsePower;
    private int acceleration;
    private int suspension;
    private int durability;

    public Car(string brand, string model, int yearOfProduction, int horsePower, int acceleration, int suspension, int durability)
    {
        this.Brand = brand;
        this.Model = model;
        this.YearOfProduction = yearOfProduction;
        this.HorsePower = horsePower;
        this.Acceleration = acceleration;
        this.Suspension = suspension;
        this.Durability = durability;
    }

    public int Durability
    {
        get { return this.durability; }
        set { this.durability = value; }
    }

    public int Suspension
    {
        get { return this.suspension; }
        set { this.suspension = value; }
    }

    public int Acceleration
    {
        get { return this.acceleration; }
        protected set { this.acceleration = value; }
    }

    public int HorsePower
    {
        get { return this.horsePower; }
        set { this.horsePower = value; }
    }

    public int YearOfProduction
    {
        get { return this.yearOfProduction; }
        protected set { this.yearOfProduction = value; }
    }

    public string Model
    {
        get { return this.model; }
        protected set { this.model = value; }
    }

    public string Brand
    {
        get { return this.brand; }
        protected set { this.brand = value; }
    }

    public virtual void Tune(int tuneIndex, string addOn)
    {
        this.HorsePower += tuneIndex;
        this.Suspension += (tuneIndex / 2);
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"{this.Brand} {this.Model} {this.YearOfProduction}");
        sb.AppendLine($"{this.HorsePower} HP, 100 m/h in {this.Acceleration} s");
        sb.AppendLine($"{this.Suspension} Suspension force, {this.Durability} Durability");

        return sb.ToString();
    }
}