using System.Collections.Generic;

namespace Problem8_MilitaryElite
{
    public interface IEngineer
    {
        ICollection<IRepair> Repairs { get; }
    }
}