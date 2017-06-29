using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Car
{
    public Car(string model, Engine engine, Cargo cargo, ICollection<Tire> tires)
    {
        this.Model = model;
        this.Engine = engine;
        this.Cargo = cargo;
        this.Tires = new List<Tire>(tires.Take(4));
    }

    public string Model { get; set; }
    public Engine Engine { get; set; }
    public Cargo Cargo { get; set; }
    public ICollection<Tire> Tires { get; set; }
}