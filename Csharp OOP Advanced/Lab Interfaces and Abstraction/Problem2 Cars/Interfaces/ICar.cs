public interface ICar
{
    string Color { get; set; }
    string Model { get; set; }

    string Start();

    string Stop();
}