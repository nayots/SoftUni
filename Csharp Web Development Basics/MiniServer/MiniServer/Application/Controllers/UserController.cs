using MiniServer.Application.Views;
using MiniServer.Server.Enums;
using MiniServer.Server.HTTP;
using MiniServer.Server.HTTP.Contracts;
using MiniServer.Server.HTTP.Response;

namespace MiniServer.Application.Controllers
{
    public class UserController
    {
        public IHttpResponse LoginGet()
        {
            return new ViewResponse(HttpStatusCode.OK, new LoginView());
        }

        public IHttpResponse LoginPost(IHttpRequest req)
        {
            if (
                (req.FormData.ContainsKey("username") &&
                req.FormData.ContainsKey("password"))
                &&
                (!string.IsNullOrEmpty(req.FormData["username"].Trim()) &&
                !string.IsNullOrEmpty(req.FormData["password"].Trim()))
                )
            {
                string username = req.FormData["username"].Trim();
                string password = req.FormData["password"].Trim();

                //Credentials Check ?

                req.Session.Add(SessionStore.CurrentUserKey, username);

                return new RedirectResponse("/");
            }
            else
            {
                return new ViewResponse(HttpStatusCode.OK, new LoginView("Red", LoginView.UsernameAndPasswordReq));
            }
        }

        public IHttpResponse Logout(IHttpRequest request)
        {
            request.Session.Clear();

            return new RedirectResponse("/");
        }
    }
}