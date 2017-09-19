using System.Collections.Generic;
using System.Text;

public class SpecialForce : Soldier
{
    private const double OverallSkillMiltiplier = 3.5;

    public SpecialForce(string name, int age, double experience, double endurance) : base(name, age, experience, endurance)
    {
        this.WeaponsAllowed = new List<string>
        {
            "Gun",
            "AutomaticMachine",
            "MachineGun",
            "RPG",
            "Helmet",
            "Knife",
            "NightVision"
        };
    }

    public override void Regenerate()
    {
        this.Endurance += (this.Age + 30);

        if (this.Endurance > 100)
        {
            this.Endurance = 100;
        }
    }
}