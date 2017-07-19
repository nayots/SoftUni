using System.Collections.Generic;

namespace Problem8_MilitaryElite
{
    public interface ICommando
    {
        ICollection<IMission> Missions { get; }
    }
}