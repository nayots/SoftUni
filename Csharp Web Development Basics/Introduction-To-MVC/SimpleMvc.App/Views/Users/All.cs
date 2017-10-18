using SimpleMvc.App.ViewModels;
using SimpleMvc.Framework.Interfaces.Generic;
using System.Text;

namespace SimpleMvc.App.Views.Users
{
    public class All : IRenderable<AllUsernamesViewModel>
    {
        public AllUsernamesViewModel Model { get; set; }

        public string Render()
        {
            StringBuilder sb = new StringBuilder();
            sb.AppendLine("<a href=\"/home/index\">&lArr;Home</a>");
            sb.AppendLine("<h3>All users</h3>");
            sb.AppendLine("<ul>");
            foreach (var kvp in Model.UsernamesAndIds)
            {
                sb.AppendLine($"<li><a href=\"/users/profile?id={kvp.Value}\">{kvp.Key}</a></li>");
            }
            sb.AppendLine("</ul>");

            return sb.ToString();
        }
    }
}