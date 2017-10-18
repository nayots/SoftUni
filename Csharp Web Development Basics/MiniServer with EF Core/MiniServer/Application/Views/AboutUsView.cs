using MiniServer.Server.Contracts;
using System.IO;

namespace MiniServer.Application.Views
{
    public class AboutUsView : IView
    {
        public string View()
        {
            string html = File.ReadAllText(@".\Application\Resources\about.html");

            return html;
        }
    }
}