using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem10_CarSalesman
{
    public class Engine
    {
        public Engine(string model, int power)
        {
            this.Model = model;
            this.Power = power;
        }

        public string Model { get; set; }
        public int Power { get; set; }
        public int? Displacement { get; set; }
        public string Efficiency { get; set; }
    }
}