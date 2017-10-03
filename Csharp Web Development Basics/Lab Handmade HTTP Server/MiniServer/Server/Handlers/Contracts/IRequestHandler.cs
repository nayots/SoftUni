using MiniServer.Server.HTTP.Contracts;

namespace MiniServer.Server.Handlers.Contracts
{
    public interface IRequestHandler
    {
        IHttpResponse Handle(IHttpContext httpContext);
    }
}