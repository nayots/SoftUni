using System.Collections.Generic;

namespace Problem4_Telephony.Interfaces
{
    public interface ICallable
    {
        ICollection<string> Numbers { get; }

        string Call(string number);
    }
}