using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class PerformanceCar : Car
{
    private IList<string> addOns;

    public PerformanceCar(string brand, string model, int yearOfProduction, int horsePower, int acceleration, int suspension, int durability) : base(brand, model, yearOfProduction, (horsePower * 150) / 100, acceleration, (suspension * 75) / 100, durability)
    {
        this.AddOns = new List<string>();
    }

    public IList<string> AddOns
    {
        get { return this.addOns; }
        set { this.addOns = value; }
    }

    public override void Tune(int tuneIndex, string addOn)
    {
        base.Tune(tuneIndex, addOn);
        this.AddOns.Add(addOn);
    }

    public override string ToString()
    {
        string result = base.ToString();

        result += "Add-ons: ";
        if (this.AddOns.Count <= 0)
        {
            result += "None";
        }
        else
        {
            result += string.Join(", ", this.AddOns);
        }

        return result;
    }
}