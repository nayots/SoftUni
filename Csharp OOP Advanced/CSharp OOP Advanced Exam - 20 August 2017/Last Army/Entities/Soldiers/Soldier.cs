using System.Collections.Generic;
using System.Linq;

public abstract class Soldier : ISoldier
{
    public Soldier(string name, int age, double experience, double endurance)
    {
        this.Age = age;
        this.Endurance = endurance;
        this.Experience = experience;
        this.Name = name;
        this.Weapons = new Dictionary<string, IAmmunition>();
    }

    public int Age { get; protected set; }
    public double Endurance { get; protected set; }
    public double Experience { get; protected set; }
    public string Name { get; protected set; }
    public double OverallSkill { get; protected set; }
    public IDictionary<string, IAmmunition> Weapons { get; protected set; }
    public List<string> WeaponsAllowed { get; protected set; }

    public void CompleteMission(IMission mission)
    {
        throw new System.NotImplementedException();
    }

    public bool ReadyForMission(IMission mission)
    {
        if (this.Endurance < mission.EnduranceRequired)
        {
            return false;
        }

        bool hasAllEquipment = this.Weapons.Values.Count(weapon => weapon == null) == 0;

        if (!hasAllEquipment)
        {
            return false;
        }

        return this.Weapons.Values.Count(weapon => weapon.WearLevel >= 0) == 0;
    }

    public abstract void Regenerate();

    public override string ToString() => string.Format(OutputMessages.SoldierToString, this.Name, this.OverallSkill);

    private void AmmunitionRevision(double missionWearLevelDecrement)
    {
        IEnumerable<string> keys = this.Weapons.Keys.ToList();
        foreach (string weaponName in keys)
        {
            this.Weapons[weaponName].DecreaseWearLevel(missionWearLevelDecrement);

            if (this.Weapons[weaponName].WearLevel <= 0)
            {
                this.Weapons[weaponName] = null;
            }
        }
    }
}