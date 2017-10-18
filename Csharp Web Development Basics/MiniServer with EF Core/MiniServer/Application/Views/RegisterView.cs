using MiniServer.Server.Contracts;
using System.IO;

namespace MiniServer.Application.Views
{
    public class RegisterView : IView
    {
        private const string MessageSnip = @"<!--message-->";
        private string errorMessage;

        public RegisterView(string errorMessage = null)
        {
            this.errorMessage = errorMessage;
        }

        public string View()
        {
            string html = File.ReadAllText(@".\Application\Resources\register.html");

            if (errorMessage != null)
            {
                html = html.Replace(MessageSnip, $"<h4 style=\"color:Red\">{this.errorMessage}</h4>");
            }

            return html;
        }
    }
}