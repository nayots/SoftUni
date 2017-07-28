using System.Collections.Generic;

namespace InfernoInfinity.Interfaces
{
    public interface IGemFactory
    {
        IBaseGem Create(IList<string> tokens);
    }
}