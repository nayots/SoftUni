using MiniServer.Server.Enums;
using System.Collections.Generic;

namespace MiniServer.Server.Routing.Contracts
{
    public interface IServerRouteConfig
    {
        Dictionary<HttpRequestMethod, Dictionary<string, IRoutingContext>> Routes { get; }
    }
}