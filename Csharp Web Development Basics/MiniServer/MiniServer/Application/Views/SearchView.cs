using MiniServer.Application.Models;
using MiniServer.Server.Contracts;
using System.IO;

namespace MiniServer.Application.Views
{
    public class SearchView : IView
    {
        private const string ReplacementSnip = "<!--replace-->";
        private const string ProductCountSnip = "<!--productsCount-->";

        private string cakeSearchName;
        private int productCount;

        public SearchView(string cakeName, int productCount)
        {
            this.cakeSearchName = cakeName;
            this.productCount = productCount;
        }

        public string View()
        {
            string html = File.ReadAllText(@".\Application\Resources\search.html");

            if (!string.IsNullOrEmpty(this.cakeSearchName) && !string.IsNullOrWhiteSpace(this.cakeSearchName))
            {
                string cakesHtml = CakeList.GetCakesAsHtmlString(this.cakeSearchName);

                html = html.Replace(ReplacementSnip, cakesHtml);
            }

            string productsMessage = productCount <= 1 ? $"{productCount} product" : $"{productCount} products";

            html = html.Replace(ProductCountSnip, productsMessage);

            return html;
        }
    }
}