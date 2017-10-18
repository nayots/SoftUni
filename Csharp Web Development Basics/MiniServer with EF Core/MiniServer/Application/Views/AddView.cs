using MiniServer.Server.Contracts;
using System.IO;

namespace MiniServer.Application.Views
{
    public class AddView : IView
    {
        public string View()
        {
            string html = File.ReadAllText(@".\Application\Resources\add.html");

            return html;
        }
    }
}