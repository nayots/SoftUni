using MiniServer.Server.Handlers;
using System.Collections.Generic;

namespace MiniServer.Server.Routing.Contracts
{
    public interface IRoutingContext
    {
        IEnumerable<string> Parameters { get; }

        RequestHandler RequestHandler { get; }
    }
}