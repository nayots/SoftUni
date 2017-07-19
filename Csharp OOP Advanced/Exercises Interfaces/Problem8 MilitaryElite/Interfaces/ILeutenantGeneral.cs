using System.Collections.Generic;

namespace Problem8_MilitaryElite
{
    public interface ILeutenantGeneral
    {
        ICollection<IPrivate> Privates { get; }
    }
}