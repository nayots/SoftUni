using MiniServer.Application.Models;
using MiniServer.Server.Contracts;
using System.IO;

namespace MiniServer.Application.Views
{
    public class AddView : IView
    {
        private const string ReplacementSnip = "<!--replace-->";

        public string View()
        {
            string html = File.ReadAllText(@".\Application\Resources\add.html");

            string cakesHtml = CakeList.GetCakesAsHtmlString();

            html = html.Replace(ReplacementSnip, cakesHtml);

            return html;
        }
    }
}