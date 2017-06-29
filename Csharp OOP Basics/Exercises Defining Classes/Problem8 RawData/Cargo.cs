using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Cargo
{
    public Cargo(int weight, string type)
    {
        this.Weight = weight;
        this.Type = type;
    }

    public int Weight { get; set; }
    public string Type { get; set; }
}