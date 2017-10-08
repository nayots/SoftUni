using MiniServer.Application.Models;
using MiniServer.Application.Views;
using MiniServer.Server.Enums;
using MiniServer.Server.HTTP;
using MiniServer.Server.HTTP.Contracts;
using MiniServer.Server.HTTP.Response;
using System;

namespace MiniServer.Application.Controllers
{
    public class HomeController
    {
        public IHttpResponse AboutUs()
        {
            return new ViewResponse(HttpStatusCode.OK, new AboutUsView());
        }

        public IHttpResponse AddGet()
        {
            return new ViewResponse(HttpStatusCode.OK, new AddView());
        }

        public IHttpResponse AddPost(string name, double price)
        {
            name = name.Replace(",", string.Empty).Trim();
            if (!string.IsNullOrEmpty(name) && !string.IsNullOrWhiteSpace(name))
            {
                CakeList.Add(new Cake(CakeList.GenerateId(), name, price));
            }

            return new RedirectResponse($"/add");
        }

        public IHttpResponse Image(string imagePath)
        {
            return new ImageResponse(imagePath);
        }

        public IHttpResponse Index()
        {
            var response = new ViewResponse(HttpStatusCode.OK, new HomeIndexView());

            response.CookieCollection.Add(new HttpCookie("lang", "en"));

            return response;
        }

        public IHttpResponse SearchGet(IHttpRequest req)
        {
            string cakeName = string.Empty;

            if (req.QueryParameters.ContainsKey("name"))
            {
                cakeName = req.QueryParameters["name"];
            }

            int productCount = 0;

            var cart = req.Session.Get<ShoppingCart>("cart");

            if (cart != null)
            {
                productCount = cart.Cakes.Count;
            }

            return new ViewResponse(HttpStatusCode.OK, new SearchView(cakeName, productCount));
        }

        public IHttpResponse SessionTest(IHttpRequest req)
        {
            var session = req.Session;

            const string sessionDateKey = "saved_date";

            if (session.Get(sessionDateKey) == null)
            {
                session.Add(sessionDateKey, DateTime.UtcNow);
            }

            return new ViewResponse(
                HttpStatusCode.OK,
                new SessionTestView(session.Get<DateTime>(sessionDateKey)));
        }
    }
}