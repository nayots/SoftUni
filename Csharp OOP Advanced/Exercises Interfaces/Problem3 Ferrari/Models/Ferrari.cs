using Problem3_Ferrari.Interfaces;
using System.Text;

namespace Problem3_Ferrari.Models
{
    public class Ferrari : ICar
    {
        public Ferrari(string driver)
        {
            this.Driver = driver;
        }

        public string Driver { get; private set; }
        public string Model { get => "488-Spider"; }

        public string Brakes()
        {
            return "Brakes!";
        }

        public string Gas()
        {
            return "Zadu6avam sA!";
        }

        public override string ToString()
        {
            var sb = new StringBuilder();
            sb.Append($"{this.Model}/{this.Brakes()}/{this.Gas()}/{this.Driver}");

            return sb.ToString();
        }
    }
}