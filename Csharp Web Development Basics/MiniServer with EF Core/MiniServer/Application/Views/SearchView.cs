using MiniServer.Data;
using MiniServer.Server.Contracts;
using System.IO;
using System.Text;

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

            string cakesHtml = string.Empty;

            using (var repo = new ProductRepository(new ShopDbContext()))
            {
                var cakes = repo.GetProducts(this.cakeSearchName);

                var sb = new StringBuilder();

                foreach (var cake in cakes)
                {
                    sb.AppendLine(cake.GetHtml(this.cakeSearchName));
                }

                cakesHtml = sb.ToString();
            }

            html = html.Replace(ReplacementSnip, cakesHtml);

            string productsMessage = productCount <= 1 ? $"{productCount} product" : $"{productCount} products";

            html = html.Replace(ProductCountSnip, productsMessage);

            return html;
        }
    }
}