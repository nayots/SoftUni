using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Garage
{
    private HashSet<Car> parkedCars;

    public Garage()
    {
        this.ParkedCars = new HashSet<Car>();
    }

    public HashSet<Car> ParkedCars
    {
        get { return this.parkedCars; }
        private set { this.parkedCars = value; }
    }
}