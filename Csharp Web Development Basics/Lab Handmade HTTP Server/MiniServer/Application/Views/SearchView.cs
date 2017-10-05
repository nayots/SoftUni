using MiniServer.Application.Models;
using MiniServer.Server.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniServer.Application.Views
{
    public class SearchView : IView
    {
        private const string ReplacementSnip = "<!--replace-->";

        private string cakeSearchName;

        public SearchView(string cakeName)
        {
            this.cakeSearchName = cakeName;
        }

        public string View()
        {
            string html = File.ReadAllText(@".\Application\Resources\search.html");

            if (!string.IsNullOrEmpty(this.cakeSearchName) && !string.IsNullOrWhiteSpace(this.cakeSearchName))
            {
                string cakesHtml = CakeList.GetCakesAsHtmlString(this.cakeSearchName);

                html = html.Replace(ReplacementSnip, cakesHtml);
            }

            return html;
        }
    }
}