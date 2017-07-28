using System.Collections.Generic;

namespace InfernoInfinity.Interfaces
{
    public interface IInputHandler
    {
        List<string> SplitInput(string input, string splitValue);
    }
}