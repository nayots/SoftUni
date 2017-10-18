using MiniServer.Models;
using MiniServer.Server.Contracts;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;

namespace MiniServer.Application.Views
{
    public class OrdersView : IView
    {
        private const string OrdersTableDataPattern = @"<tr><td><a href=""/orderDetails/{0}"">{0}</a></td><td>{1}</td><td>${2}</td></tr>";
        private const string OrdersSnip = @"<!--orders-->";
        private ICollection<Order> orders;

        public OrdersView(ICollection<Order> orders)
        {
            this.orders = orders;
        }

        public string View()
        {
            string html = File.ReadAllText(@".\Application\Resources\orders.html");

            var sb = new StringBuilder();

            foreach (var order in this.orders.OrderByDescending(o => o.CreationDate))
            {
                int orderId = order.Id;
                string orderDate = order.CreationDate.ToString("dd-MM-yyyy");
                double orderSum = order.Products.Sum(p => p.Product.Price);

                string row = string.Format(OrdersTableDataPattern, orderId, orderDate, orderSum.ToString("F2"));

                sb.AppendLine(row);
            }

            if (sb.Length > 1)
            {
                html = html.Replace(OrdersSnip, sb.ToString());
            }
            else
            {
                html = html.Replace(OrdersSnip, @"<tr><td colspan=""3"">No orders :(</td></tr>");
            }

            return html;
        }
    }
}