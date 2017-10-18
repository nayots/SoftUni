using MiniServer.Application.Models;
using MiniServer.Server.Contracts;
using MiniServer.Server.HTTP.Contracts;
using System.IO;
using System.Text;

namespace MiniServer.Application.Views
{
    public class CartView : IView
    {
        private const string CakesSnip = @"<!--cakes-->";
        private const string CostSnip = @"<!--cost-->";
        private const string MessageSnip = @"<!--message-->";

        private IHttpRequest req;
        private string message;

        public CartView(IHttpRequest req, string message = null)
        {
            this.req = req;
            this.message = message;
        }

        public string View()
        {
            string html = File.ReadAllText(@".\Application\Resources\cart.html");

            var cart = req.Session.Get<ShoppingCart>("cart");
            double cost = 0;

            if (cart != null)
            {
                var cakes = new StringBuilder();

                foreach (var cake in cart.Cakes)
                {
                    cakes.AppendLine(cake.ToString());
                }

                html = html.Replace(CakesSnip, cakes.ToString());

                cost = cart.GetTotalCakesCost();
            }

            if (this.message != null)
            {
                html = html.Replace(MessageSnip, $"<h4 style=\"color:Red\">{this.message}</h4>");
            }

            html = html.Replace(CostSnip, $"<p>Total Cost: ${cost}</p>");

            return html;
        }
    }
}