using MiniServer.Models;
using MiniServer.Server.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Text;

namespace MiniServer.Application.Views
{
    public class OrderDetailsView : IView
    {
        private const string ProductsSnip = @"<!--products-->";
        private const string OrderIdSnip = @"<!--id-->";
        private const string OrderDateSnip = @"<!--createdDate-->";
        private const string ProductTableRowPattern = @"<tr><td>{0}</td><td>${1}</td></tr>";

        private int orderId;
        private DateTime orderDate;
        private ICollection<Product> products;

        public OrderDetailsView(int orderId, DateTime orderDate, ICollection<Product> products)
        {
            this.orderId = orderId;
            this.orderDate = orderDate;
            this.products = products;
        }

        public string View()
        {
            string html = File.ReadAllText(@".\Application\Resources\orderDetails.html");

            var sb = new StringBuilder();

            foreach (var product in this.products)
            {
                string productLink = product.GetProductLink();
                string priceFormatted = product.Price.ToString("F2");

                string row = string.Format(ProductTableRowPattern, productLink, priceFormatted);

                sb.AppendLine(row);
            }

            html = html.Replace(ProductsSnip, sb.ToString());
            html = html.Replace(OrderIdSnip, this.orderId.ToString());
            html = html.Replace(OrderDateSnip, this.orderDate.ToString("dd-MM-yyyy"));

            return html;
        }
    }
}