public class Gun : Ammunition
{
    private const double WeaponWeight = 1.4;

    public Gun(string name)
        : base(name, WeaponWeight)
    {
    }
}