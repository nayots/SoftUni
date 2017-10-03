using MiniServer.Server.Contracts;
using MiniServer.Server.Enums;

namespace MiniServer.Server.HTTP.Response
{
    public class ViewResponse : HttpResponse
    {
        public ViewResponse(HttpStatusCode responseCode, IView view) : base(responseCode, view)
        {
        }
    }
}