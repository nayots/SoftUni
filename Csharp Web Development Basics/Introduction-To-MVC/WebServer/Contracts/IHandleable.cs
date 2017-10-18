using WebServer.Http.Contracts;

namespace WebServer.Contracts
{
    public interface IHandleable
    {
        IHttpResponse Handle(IHttpRequest request);
    }
}