public abstract class Ammunition : IAmmunition
{
    public Ammunition(string name, double weight)
    {
        Name = name;
        Weight = weight;
        WearLevel = this.Weight * 100;
    }

    public string Name { get; protected set; }

    public double Weight { get; protected set; }

    public double WearLevel { get; protected set; }

    public void DecreaseWearLevel(double wearAmount)
    {
        this.WearLevel -= wearAmount;
    }

    //public bool WearLevelIsZero
    //{
    //    get
    //    {
    //        return this.WearLevel <= 0;
    //    }
    //}
}