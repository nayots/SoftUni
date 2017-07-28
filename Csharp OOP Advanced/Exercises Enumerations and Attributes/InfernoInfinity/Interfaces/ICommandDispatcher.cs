using System.Collections.Generic;

namespace InfernoInfinity.Interfaces
{
    public interface ICommandDispatcher
    {
        void ExecuteCommand(IList<string> tokens);
    }
}