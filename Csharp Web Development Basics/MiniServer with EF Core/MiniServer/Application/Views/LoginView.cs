using MiniServer.Server.Contracts;
using System.IO;

namespace MiniServer.Application.Views
{
    public class LoginView : IView
    {
        public const string UsernameAndPasswordReq = "Username and password are required field!";
        public const string UsernameAndPasswordIncorrect = "Username or password are incorrect!";
        private const string ColorKeyword = @"<!--color-->";
        private const string MessageKeyword = @"<!--message-->";

        private string color;
        private string message;

        public LoginView()
        {
        }

        public LoginView(string color, string message)
        {
            this.color = color;
            this.message = message;
        }

        public string View()
        {
            string html = File.ReadAllText(@".\Application\Resources\login.html");

            if (color != null && message != null)
            {
                html = html.Replace(ColorKeyword, this.color);
                html = html.Replace(MessageKeyword, this.message);
            }

            return html;
        }
    }
}