using System.Collections.Generic;

public class Corporal : Soldier
{
    public Corporal(string name, int age, double experience, double endurance) : base(name, age, experience, endurance)
    {
        this.WeaponsAllowed = new List<string>
        {
            "Gun",
            "AutomaticMachine",
            "MachineGun",
            "Helmet",
            "Knife"
        };
    }

    public override void Regenerate()
    {
        this.Endurance += (this.Age + 10);

        if (this.Endurance > 100)
        {
            this.Endurance = 100;
        }
    }
}