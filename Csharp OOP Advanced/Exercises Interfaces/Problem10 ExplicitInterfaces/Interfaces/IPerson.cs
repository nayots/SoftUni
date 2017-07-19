namespace Problem10_ExplicitInterfaces.Interfaces
{
    public interface IPerson : IHuman
    {
        int Age { get; }

        string GetName();
    }
}