public class Wizard : AbstractHero
{
    public Wizard(string name)
    {
        this.Name = name;
        this.Strength = 25;
        this.Agility = 25;
        this.Intelligence = 100;
        this.HitPoints = 100;
        this.Damage = 250;
    }
}