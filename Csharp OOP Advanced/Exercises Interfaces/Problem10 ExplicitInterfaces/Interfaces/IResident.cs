namespace Problem10_ExplicitInterfaces.Interfaces
{
    public interface IResident : IHuman
    {
        string Country { get; }

        string GetName();
    }
}