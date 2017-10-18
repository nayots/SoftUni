using MiniServer.Server.Enums;
using MiniServer.Server.Handlers;
using System.Collections.Generic;

namespace MiniServer.Server.Routing.Contracts
{
    public interface IAppRouteConfig
    {
        IReadOnlyDictionary<HttpRequestMethod, Dictionary<string, RequestHandler>> Routes { get; }

        void AddRoute(string route, RequestHandler httpHandler);
    }
}