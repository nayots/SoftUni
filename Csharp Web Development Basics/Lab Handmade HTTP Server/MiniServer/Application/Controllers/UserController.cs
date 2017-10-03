using MiniServer.Application.Views;
using MiniServer.Server;
using MiniServer.Server.Enums;
using MiniServer.Server.HTTP.Contracts;
using MiniServer.Server.HTTP.Response;

namespace MiniServer.Application.Controllers
{
    public class UserController
    {
        public IHttpResponse RegisterGet()
        {
            return new ViewResponse(HttpStatusCode.OK, new RegisterView());
        }

        public IHttpResponse RegisterPost(string name)
        {
            return new RedirectResponse($"/user/{name}");
        }

        public IHttpResponse Details(string name)
        {
            Model model = new Model { ["name"] = name };
            return new ViewResponse(HttpStatusCode.OK, new UserDetailsView(model));
        }
    }
}