using MiniServer.Server.Handlers.Contracts;
using MiniServer.Server.HTTP;
using MiniServer.Server.HTTP.Contracts;
using MiniServer.Server.HTTP.Response;
using System;

namespace MiniServer.Server.Handlers
{
    public abstract class RequestHandler : IRequestHandler
    {
        private readonly Func<IHttpContext, IHttpResponse> func;

        protected RequestHandler(Func<IHttpContext, IHttpResponse> func)
        {
            this.func = func;
        }

        public IHttpResponse Handle(IHttpContext httpContext)
        {
            string sessionIdToSend = null;

            if (!httpContext.Request.Cookies.ContainsKey(SessionStore.SessionCookieKey))
            {
                var sessionId = Guid.NewGuid().ToString();

                httpContext.Request.Session = SessionStore.Get(sessionId);

                sessionIdToSend = sessionId;
            }

            IHttpResponse httpResponse = this.func.Invoke(httpContext);

            if (!(httpResponse is ImageResponse))
            {
                httpResponse.AddHeader("Content-Type", "text/html");
            }

            if (sessionIdToSend != null)
            {
                httpResponse.AddHeader("Set-Cookie", $"{SessionStore.SessionCookieKey}={sessionIdToSend}; HttpOnly; path=/");
            }
            this.SetCookies(httpContext, httpResponse);

            return httpResponse;
        }

        private void SetCookies(IHttpContext httpContext, IHttpResponse httpResponse)
        {
            var cookies = httpResponse.CookieCollection;
            foreach (HttpCookie cookie in cookies)
            {
                if (cookie.IsNew)
                {
                    httpResponse.AddHeader("Set-Cookie", cookie.ToString());
                }
            }
        }
    }
}