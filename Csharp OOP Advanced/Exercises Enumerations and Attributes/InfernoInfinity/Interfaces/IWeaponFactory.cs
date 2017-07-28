using System.Collections.Generic;

namespace InfernoInfinity.Interfaces
{
    public interface IWeaponFactory
    {
        IWeapon Create(IList<string> tokens);
    }
}