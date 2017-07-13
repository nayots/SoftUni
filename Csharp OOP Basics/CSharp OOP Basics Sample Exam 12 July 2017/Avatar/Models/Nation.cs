using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Nation
{
    private List<Bender> benders;
    private List<Monument> monuments;
    private string nationType;

    public Nation(string type)
    {
        this.Benders = new List<Bender>();
        this.Monuments = new List<Monument>();
        this.nationType = type;
    }

    public List<Bender> Benders
    {
        get { return this.benders; }
        private set { this.benders = value; }
    }

    public List<Monument> Monuments
    {
        get { return this.monuments; }
        private set { this.monuments = value; }
    }

    public double NationsBenderPower { get { return this.CalculateNationsPower(); } }

    public double NationsTotalPower { get { return this.CalculateNationsTotalPowerWithMonuments(); } }

    private double CalculateNationsPower()
    {
        return this.Benders.Sum(b => b.GetBenderTotalPower());
    }

    private double CalculateNationsTotalPowerWithMonuments()
    {
        int increase = this.Monuments.Sum(m => m.GetAffinity());

        return ((this.NationsBenderPower / 100) * increase) + this.NationsBenderPower;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();
        sb.AppendLine($"{this.nationType} Nation");
        if (this.Benders.Count > 0)
        {
            sb.AppendLine("Benders:");
            foreach (var b in this.Benders)
            {
                sb.AppendLine($"###{b.ToString()}");
            }
        }
        else
        {
            sb.AppendLine("Benders: None");
        }

        if (this.Monuments.Count > 0)
        {
            sb.AppendLine("Monuments:");
            foreach (var m in this.Monuments)
            {
                sb.AppendLine($"###{m.ToString()}");
            }
        }
        else
        {
            sb.AppendLine("Monuments: None");
        }

        return sb.ToString();
    }
}