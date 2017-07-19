public abstract class Car : ICar
{
    public Car(string model, string color)
    {
        this.Model = model;
        this.Color = color;
    }

    public string Color
    {
        get;
        set;
    }

    public string Model
    {
        get;
        set;
    }

    public string Start()
    {
        return "Engine start";
    }

    public string Stop()
    {
        return "Breaaak!";
    }
}