using System.Collections.Generic;
using System.Linq;

public class Army : IArmy
{
    public Army()
    {
        this.Members = new Dictionary<string, List<ISoldier>>();
    }

    public Dictionary<string, List<ISoldier>> Members { get; set; }

    public IReadOnlyList<ISoldier> Soldiers
    {
        get
        {
            return this.Members.Values.SelectMany(x => x).ToList();
        }
    }

    public void AddSoldier(ISoldier soldier)
    {
        if (!this.Members.ContainsKey(soldier.GetType().Name))
        {
            this.Members[soldier.GetType().Name] = new List<ISoldier>();
            this.Members[soldier.GetType().Name].Add(soldier);
        }
        else
        {
            this.Members[soldier.GetType().Name].Add(soldier);
        }
    }

    public void RegenerateTeam(string soldierType)
    {
        if (this.Members.ContainsKey(soldierType))
        {
            foreach (var soldier in this.Members[soldierType])
            {
                soldier.Regenerate();
            }
        }
    }
}