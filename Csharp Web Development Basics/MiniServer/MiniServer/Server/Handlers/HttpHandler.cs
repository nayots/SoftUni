using MiniServer.Application.Views;
using MiniServer.Server.Handlers.Contracts;
using MiniServer.Server.HTTP;
using MiniServer.Server.HTTP.Contracts;
using MiniServer.Server.HTTP.Response;
using MiniServer.Server.Routing.Contracts;
using System.Collections.Generic;
using System.Text.RegularExpressions;

namespace MiniServer.Server.Handlers
{
    public class HttpHandler : IRequestHandler
    {
        private readonly IServerRouteConfig serverRouteConfig;

        public HttpHandler(IServerRouteConfig serverRouteConfig)
        {
            this.serverRouteConfig = serverRouteConfig;
        }

        public IHttpResponse Handle(IHttpContext httpContext)
        {
            // Check if user is authenticated
            var loginPath = "/login";

            if (httpContext.Request.Path != loginPath &&
                !httpContext.Request.Session.Contains(SessionStore.CurrentUserKey))
            {
                return new RedirectResponse(loginPath);
            }

            foreach (KeyValuePair<string, IRoutingContext> kvp in this.serverRouteConfig.Routes[httpContext.Request.RequestMethod])
            {
                string pattern = kvp.Key;
                Regex regex = new Regex(pattern);
                Match match = regex.Match(httpContext.Request.Path);

                if (!match.Success)
                {
                    continue;
                }

                foreach (string parameter in kvp.Value.Parameters)
                {
                    httpContext.Request.AddUrlParameter(parameter, match.Groups[parameter].Value);
                }

                return kvp.Value.RequestHandler.Handle(httpContext);
            }

            return new ViewResponse(Enums.HttpStatusCode.NotFound, new NotFoundView());
        }
    }
}