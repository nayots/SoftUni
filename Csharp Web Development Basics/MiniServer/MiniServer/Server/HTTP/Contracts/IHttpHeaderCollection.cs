using System.Collections.Generic;

namespace MiniServer.Server.HTTP.Contracts
{
    public interface IHttpHeaderCollection : IEnumerable<ICollection<HttpHeader>>
    {
        void Add(HttpHeader header);

        bool ContainsKey(string key);

        ICollection<HttpHeader> GetHeader(string key);
    }
}