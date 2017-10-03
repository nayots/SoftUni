using MiniServer.Application.Controllers;
using MiniServer.Server.Contracts;
using MiniServer.Server.Handlers;
using MiniServer.Server.Routing.Contracts;

namespace MiniServer.Application
{
    public class MainApplication : IApplication
    {
        public void Start(IAppRouteConfig appRouteConfig)
        {
            appRouteConfig.AddRoute("/", new GETHandler(httpContext => new HomeController().Index()));

            appRouteConfig.AddRoute(
                "/register",
                new POSTHandler(
                    httpContext => new UserController()
                    .RegisterPost(httpContext.Request.FormData["name"])));
            appRouteConfig.AddRoute(
                "/register",
                new GETHandler(httpContext => new UserController().RegisterGet()));

            appRouteConfig.AddRoute(
                "/user/{(?<name>[a-zA-Z]+)}",
                new GETHandler(httpContext => new UserController()
                .Details(httpContext.Request.UrlParameters["name"])));

            appRouteConfig.AddRoute(
                @"/Images/{(?<imagePath>[a-zA-Z0-9_]+\.(jpg|png))}",
                new GETHandler(httpContext => new HomeController()
                .Image(httpContext.Request.UrlParameters["imagePath"])));
        }
    }
}