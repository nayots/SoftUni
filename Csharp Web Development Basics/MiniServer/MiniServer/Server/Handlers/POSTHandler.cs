using MiniServer.Server.HTTP.Contracts;
using System;

namespace MiniServer.Server.Handlers
{
    public class POSTHandler : RequestHandler
    {
        public POSTHandler(Func<IHttpContext, IHttpResponse> func) : base(func)
        {
        }
    }
}