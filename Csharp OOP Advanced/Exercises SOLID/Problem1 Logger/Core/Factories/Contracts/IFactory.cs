using System.Collections.Generic;

namespace Problem1_Logger.Core.Factories
{
    public interface IFactory<T>
    {
        T Create(IList<string> data);
    }
}