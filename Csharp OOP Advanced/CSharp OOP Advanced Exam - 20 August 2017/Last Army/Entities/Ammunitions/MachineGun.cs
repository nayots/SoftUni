public class MachineGun : Ammunition
{
    private const double WeaponWeight = 10.6;

    public MachineGun(string name)
        : base(name, WeaponWeight)
    {
    }
}