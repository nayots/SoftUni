public interface IWeapon
{
    int AttackPoints { get; set; }
    int DurabilityPoints { get; set; }

    void Attack(ITarget target);
}