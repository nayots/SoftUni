namespace _02.Graphic_Editor
{
    public interface IShape
    {
        double X { get; set; }

        double Y { get; set; }

        void Draw();
    }
}