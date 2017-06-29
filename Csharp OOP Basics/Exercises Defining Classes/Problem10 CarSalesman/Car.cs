using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem10_CarSalesman
{
    public class Car
    {
        public Car(string model, Engine engine)
        {
            this.Model = model;
            this.Engine = engine;
        }

        public string Model { get; set; }
        public Engine Engine { get; set; }
        public int? Weight { get; set; }
        public string Color { get; set; }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine($"{this.Model}:");
            sb.AppendLine($"  {this.Engine.Model}:");
            sb.AppendLine($"    Power: {this.Engine.Power}");
            if (this.Engine.Displacement is null)
            {
                sb.AppendLine($"    Displacement: n/a");
            }
            else
            {
                sb.AppendLine($"    Displacement: {this.Engine.Displacement.Value}");
            }
            if (string.IsNullOrEmpty(this.Engine.Efficiency))
            {
                sb.AppendLine($"    Efficiency: n/a");
            }
            else
            {
                sb.AppendLine($"    Efficiency: {this.Engine.Efficiency}");
            }
            if (this.Weight is null)
            {
                sb.AppendLine($"  Weight: n/a");
            }
            else
            {
                sb.AppendLine($"  Weight: {this.Weight}");
            }
            if (string.IsNullOrEmpty(this.Color))
            {
                sb.AppendLine($"  Color: n/a");
            }
            else
            {
                sb.AppendLine($"  Color: {this.Color}");
            }

            return sb.ToString();
        }
    }
}