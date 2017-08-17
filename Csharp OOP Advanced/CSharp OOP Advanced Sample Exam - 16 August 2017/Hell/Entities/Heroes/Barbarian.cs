public class Barbarian : AbstractHero
{
    public Barbarian(string name)
    {
        this.Name = name;
        this.Strength = 90;
        this.Agility = 25;
        this.Intelligence = 10;
        this.HitPoints = 350;
        this.Damage = 150;
    }
}