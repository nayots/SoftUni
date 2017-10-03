using MiniServer.Application.Views;
using MiniServer.Server.Enums;
using MiniServer.Server.HTTP.Contracts;
using MiniServer.Server.HTTP.Response;

namespace MiniServer.Application.Controllers
{
    public class HomeController
    {
        public IHttpResponse Index()
        {
            return new ViewResponse(HttpStatusCode.OK, new HomeIndexView());
        }

        public IHttpResponse Image(string imagePath)
        {
            return new ImageResponse(imagePath);
        }
    }
}