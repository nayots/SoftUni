using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class CasualRace : Race
{
    public CasualRace(int length, string route, int prizePool) : base(length, route, prizePool)
    {
    }

    public override int GetPerformancePoints(Car car)
    {
        return (car.HorsePower / car.Acceleration) + car.Suspension + car.Durability;
    }
}