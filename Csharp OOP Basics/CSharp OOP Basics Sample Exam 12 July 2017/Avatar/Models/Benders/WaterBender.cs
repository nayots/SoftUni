using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class WaterBender : Bender
{
    private double waterClarity;

    public WaterBender(string name, int power, double waterClarity) : base(name, power)
    {
        this.WaterClarity = waterClarity;
    }

    public double WaterClarity
    {
        get { return this.waterClarity; }
        set { this.waterClarity = value; }
    }

    public override double GetBenderTotalPower()
    {
        return this.Power * this.WaterClarity;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.Append($"Water Bender: {this.Name}, Power: {this.Power}, Water Clarity: {this.WaterClarity:F2}");

        return sb.ToString();
    }
}