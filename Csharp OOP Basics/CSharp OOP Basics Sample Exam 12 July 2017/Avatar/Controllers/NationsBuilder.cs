using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class NationsBuilder
{
    private Nation airNation;
    private Nation waterNation;
    private Nation fireNation;
    private Nation earthNation;
    private List<string> records;

    public NationsBuilder()
    {
        this.airNation = new Nation("Air");
        this.waterNation = new Nation("Water");
        this.fireNation = new Nation("Fire");
        this.earthNation = new Nation("Earth");
        this.records = new List<string>();
    }

    public void AssignBender(List<string> benderArgs)
    {
        string type = benderArgs[0];
        string name = benderArgs[1];
        int power = int.Parse(benderArgs[2]);
        double specialParam = double.Parse(benderArgs[3]);
        switch (type)
        {
            case "Air":
                this.airNation.Benders.Add(new AirBender(name, power, specialParam));
                break;

            case "Water":
                this.waterNation.Benders.Add(new WaterBender(name, power, specialParam));
                break;

            case "Fire":
                this.fireNation.Benders.Add(new FireBender(name, power, specialParam));
                break;

            case "Earth":
                this.earthNation.Benders.Add(new EarthBender(name, power, specialParam));
                break;
        }
    }

    public void AssignMonument(List<string> monumentArgs)
    {
        string type = monumentArgs[0];
        string name = monumentArgs[1];
        int affinity = int.Parse(monumentArgs[2]);
        switch (type)
        {
            case "Air":
                this.airNation.Monuments.Add(new AirMonument(name, affinity));
                break;

            case "Water":
                this.waterNation.Monuments.Add(new WaterMonument(name, affinity));
                break;

            case "Fire":
                this.fireNation.Monuments.Add(new FireMonument(name, affinity));
                break;

            case "Earth":
                this.earthNation.Monuments.Add(new EarthMonument(name, affinity));
                break;
        }
    }

    public string GetStatus(string nationsType)
    {
        switch (nationsType)
        {
            case "Air":
                return this.airNation.ToString();

            case "Water":
                return this.waterNation.ToString();

            case "Fire":
                return this.fireNation.ToString();

            case "Earth":
                return this.earthNation.ToString();

            default:
                throw new ArgumentException("Invalid nation type!");
        }
    }

    public void IssueWar(string nationsType)
    {
        List<Nation> nationsAtWar = new List<Nation>();
        nationsAtWar.Add(this.airNation);
        nationsAtWar.Add(this.waterNation);
        nationsAtWar.Add(this.fireNation);
        nationsAtWar.Add(this.earthNation);

        foreach (var nation in nationsAtWar.OrderByDescending(n => n.NationsTotalPower).Skip(1))
        {
            nation.Benders.Clear();
            nation.Monuments.Clear();
        }

        this.records.Add($"War {this.records.Count + 1} issued by {nationsType}");
    }

    public string GetWarsRecord()
    {
        return string.Join(Environment.NewLine, this.records);
    }
}