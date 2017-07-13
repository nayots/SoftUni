using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class WaterMonument : Monument
{
    private int waterAffinity;

    public WaterMonument(string name, int waterAffinity) : base(name)
    {
        this.WaterAffinity = waterAffinity;
    }

    public int WaterAffinity
    {
        get { return this.waterAffinity; }
        set { this.waterAffinity = value; }
    }

    public override int GetAffinity()
    {
        return this.WaterAffinity;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.Append($"Water Monument: {this.Name}, Water Affinity: {this.WaterAffinity}");

        return sb.ToString();
    }
}