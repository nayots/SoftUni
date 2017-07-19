using System.Collections.Generic;

namespace Problem4_Telephony.Interfaces
{
    public interface IBrowser
    {
        ICollection<string> Urls { get; }

        string Browse(string url);
    }
}