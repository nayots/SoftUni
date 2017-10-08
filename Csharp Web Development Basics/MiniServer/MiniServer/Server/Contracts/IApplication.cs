using MiniServer.Server.Routing.Contracts;

namespace MiniServer.Server.Contracts
{
    public interface IApplication
    {
        void Start(IAppRouteConfig appRouteConfig);
    }
}