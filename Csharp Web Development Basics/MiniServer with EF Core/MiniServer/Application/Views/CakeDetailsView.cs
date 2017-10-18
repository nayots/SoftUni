using MiniServer.Server.Contracts;
using System.IO;

namespace MiniServer.Application.Views
{
    public class CakeDetailsView : IView
    {
        private const string CakeNameSnip = @"<!--name-->";
        private const string CakePriceSnip = @"<!--price-->";
        private const string CakeImgSnip = @"<!--image-->";

        private string cakeName;
        private double cakePrice;
        private string imgPath;

        public CakeDetailsView(string cakeName, double cakePrice, string imgPath)
        {
            this.cakeName = cakeName;
            this.cakePrice = cakePrice;
            this.imgPath = imgPath;
        }

        public string View()
        {
            string html = File.ReadAllText(@".\Application\Resources\cakeDetails.html");

            html = html.Replace(CakeNameSnip, this.cakeName);
            html = html.Replace(CakePriceSnip, $"{this.cakePrice:F2}");
            html = html.Replace(CakeImgSnip, this.imgPath);

            return html;
        }
    }
}