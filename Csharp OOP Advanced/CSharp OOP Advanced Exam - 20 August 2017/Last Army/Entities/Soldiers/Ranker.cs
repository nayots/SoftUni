using System.Collections.Generic;

public class Ranker : Soldier
{
    public Ranker(string name, int age, double experience, double endurance) : base(name, age, experience, endurance)
    {
        this.WeaponsAllowed = new List<string>
        {
            "Gun",
            "AutomaticMachine",
            "Helmet"
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