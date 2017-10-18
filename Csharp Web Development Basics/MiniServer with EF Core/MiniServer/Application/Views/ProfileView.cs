using MiniServer.Server.Contracts;
using System;
using System.IO;

namespace MiniServer.Application.Views
{
    public class ProfileView : IView
    {
        private const string UsernameSnip = @"<!--name-->";
        private const string DateSnip = @"<!--date-->";
        private const string OrdersSnip = @"<!--orders-->";

        private string username;
        private DateTime registerDate;
        private int ordersCount;

        public ProfileView(string username, DateTime registerDate, int ordersCount)
        {
            this.username = username;
            this.registerDate = registerDate;
            this.ordersCount = ordersCount;
        }

        public string View()
        {
            string html = File.ReadAllText(@".\Application\Resources\profile.html");

            html = html.Replace(UsernameSnip, this.username);
            html = html.Replace(DateSnip, this.registerDate.ToString("dd-MM-yyyy"));
            html = html.Replace(OrdersSnip, this.ordersCount.ToString());

            return html;
        }
    }
}