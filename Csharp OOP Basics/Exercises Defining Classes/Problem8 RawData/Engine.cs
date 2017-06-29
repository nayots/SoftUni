using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Engine
{
    public Engine(int speed, int power)
    {
        this.Speed = speed;
        this.Power = power;
    }

    public int Speed { get; set; }
    public int Power { get; set; }
}