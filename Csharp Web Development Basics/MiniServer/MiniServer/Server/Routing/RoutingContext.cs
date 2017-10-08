using MiniServer.Server.Handlers;
using MiniServer.Server.Routing.Contracts;
using System.Collections.Generic;

namespace MiniServer.Server.Routing
{
    public class RoutingContext : IRoutingContext
    {
        public RoutingContext(RequestHandler requestHandler, IEnumerable<string> args)
        {
            this.Parameters = args;
            this.RequestHandler = requestHandler;
        }

        public IEnumerable<string> Parameters { get; private set; }

        public RequestHandler RequestHandler { get; set; }
    }
}