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

            appRouteConfig.AddRoute("/about", new GETHandler(httpContext => new HomeController().AboutUs()));

            appRouteConfig.AddRoute("/search", new GETHandler(httpContext => new HomeController().SearchGet(httpContext.Request.QueryParameters)));

            appRouteConfig.AddRoute("/calculator", new GETHandler(httpContext => new HomeController().CalculatorGet()));
            appRouteConfig.AddRoute(
                "/calculator",
                new POSTHandler(
                    httpContext => new HomeController()
                    .CalculatorPost(httpContext.Request.FormData["val1"], httpContext.Request.FormData["sign"], httpContext.Request.FormData["val2"])));

            appRouteConfig.AddRoute(
                "/login",
                new POSTHandler(
                    httpContext => new HomeController()
                    .LoginPost(httpContext.Request.FormData)));
            appRouteConfig.AddRoute(
                 "/login",
                 new GETHandler(httpContext => new HomeController().LoginGet()));

            appRouteConfig.AddRoute(
                "/add",
                new POSTHandler(
                    httpContext => new HomeController()
                    .AddPost(httpContext.Request.FormData["name"], double.Parse(httpContext.Request.FormData["price"]))));
            appRouteConfig.AddRoute(
                "/add",
                new GETHandler(httpContext => new HomeController().AddGet()));

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

            appRouteConfig.AddRoute("/test", new GETHandler(httpContext => new HomeController().SessionTest(httpContext.Request)));

            appRouteConfig.AddRoute("/greeting", new GETHandler(httpContext => new HomeController().GreetingGet(httpContext.Request)));

            appRouteConfig.AddRoute("/greeting", new POSTHandler(httpContext => new HomeController().GreetingPost(httpContext.Request)));
        }
    }
}