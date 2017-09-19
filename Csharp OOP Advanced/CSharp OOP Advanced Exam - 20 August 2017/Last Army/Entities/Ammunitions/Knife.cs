public class Knife : Ammunition
{
    private const double WeaponWeight = 0.4;

    public Knife(string name)
        : base(name, WeaponWeight)
    {
    }
}