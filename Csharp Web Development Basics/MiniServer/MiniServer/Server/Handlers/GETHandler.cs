using MiniServer.Server.HTTP.Contracts;
using System;

namespace MiniServer.Server.Handlers
{
    public class GETHandler : RequestHandler
    {
        public GETHandler(Func<IHttpContext, IHttpResponse> func) : base(func)
        {
        }
    }
}