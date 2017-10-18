using SimpleMvc.Framework.Interfaces;
using System.Text;

namespace SimpleMvc.App.Views.Home
{
    public class Index : IRenderable
    {
        public string Render()
        {
            var sb = new StringBuilder();

            sb.AppendLine("<h2>Notes App</h2>");
            sb.AppendLine("<a href=\"/users/all\">All Users</a>");
            sb.AppendLine("<a href=\"/users/register\">Register Users</a>");

            return sb.ToString();
        }
    }
}