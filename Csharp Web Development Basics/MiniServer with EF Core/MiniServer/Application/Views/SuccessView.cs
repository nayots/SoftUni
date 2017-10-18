using MiniServer.Server.Contracts;
using System.IO;

namespace MiniServer.Application.Views
{
    public class SuccessView : IView
    {
        private const string MessageSnip = @"<!--message-->";
        private const string Success = "Thank you for your order!";
        private const string Fail = "You don't have any items in your cart.";
        private bool isSuccessful;

        public SuccessView(bool isSuccessful = true)
        {
            this.isSuccessful = isSuccessful;
        }

        public string View()
        {
            string html = File.ReadAllText(@".\Application\Resources\success.html");

            if (this.isSuccessful)
            {
                html = html.Replace(MessageSnip, Success);
            }
            else
            {
                html = html.Replace(MessageSnip, Fail);
            }

            return html;
        }
    }
}