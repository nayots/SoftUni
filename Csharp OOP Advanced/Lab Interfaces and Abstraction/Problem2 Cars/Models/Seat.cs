using System.Text;

public class Seat : Car
{
    public Seat(string model, string color) : base(model, color)
    {
    }

    public override string ToString()
    {
        var sb = new StringBuilder();

        sb.AppendLine($"{this.Color} {this.GetType().Name} {this.Model}");
        sb.AppendLine($"{this.Start()}");
        sb.Append($"{this.Stop()}");

        return sb.ToString();
    }
}