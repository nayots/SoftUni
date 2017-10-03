using MiniServer.Server.Contracts;
using System.IO;

namespace MiniServer.Application.Views
{
    public class HomeIndexView : IView
    {
        public string View()
        {
            string html = File.ReadAllText(@".\Application\Resources\index.html");

            return html;
        }
    }
}