using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class DriftRace : Race
{
    public DriftRace(int length, string route, int prizePool) : base(length, route, prizePool)
    {
    }

    public override int GetPerformancePoints(Car car)
    {
        return (car.Suspension + car.Durability);
    }
}