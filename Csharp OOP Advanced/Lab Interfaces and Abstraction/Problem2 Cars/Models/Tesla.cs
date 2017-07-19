using System.Text;

public class Tesla : Car, IElectricCar
{
    public Tesla(string model, string color, int batteries) : base(model, color)
    {
        this.Battery = batteries;
    }

    public int Battery
    {
        get;
        set;
    }

    public override string ToString()
    {
        var sb = new StringBuilder();

        sb.AppendLine($"{this.Color} {this.GetType().Name} {this.Model} with {this.Battery} Batteries");
        sb.AppendLine($"{this.Start()}");
        sb.Append($"{this.Stop()}");

        return sb.ToString();
    }
}