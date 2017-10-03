using MiniServer.Server.Contracts;

namespace MiniServer.Application.Views
{
    public class RegisterView : IView
    {
        public string View()
        {
            return
                "<body>" +
                "   <form method=\"POST\">" +
                "       Name</br>" +
                "       <input type=\"text\" name=\"name\" /><br/>" +
                "       <input type=\"submit\" />" +
                "   </form>" +
                "</br><a href=\"/\">Home</a>" +
                "</body>";
        }
    }
}