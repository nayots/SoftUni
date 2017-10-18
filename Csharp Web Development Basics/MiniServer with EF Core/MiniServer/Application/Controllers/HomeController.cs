using MiniServer.Application.Models;
using MiniServer.Application.Views;
using MiniServer.Data;
using MiniServer.Data.Contracts;
using MiniServer.Models;
using MiniServer.Server.Enums;
using MiniServer.Server.HTTP;
using MiniServer.Server.HTTP.Contracts;
using MiniServer.Server.HTTP.Response;
using System;

namespace MiniServer.Application.Controllers
{
    public class HomeController
    {
        private IProductRepository productRepository;

        public HomeController()
        {
            this.productRepository = new ProductRepository(new ShopDbContext());
        }

        public HomeController(IProductRepository productRepository)
        {
            this.productRepository = productRepository;
        }

        public IHttpResponse AboutUs()
        {
            return new ViewResponse(HttpStatusCode.OK, new AboutUsView());
        }

        public IHttpResponse AddGet()
        {
            return new ViewResponse(HttpStatusCode.OK, new AddView());
        }

        public IHttpResponse AddPost(string name, double price, string url)
        {
            name = name.Replace(",", string.Empty).Trim();
            if (!string.IsNullOrEmpty(name) && !string.IsNullOrWhiteSpace(name))
            {
                productRepository.AddProduct(new Product(name, price, url));
                productRepository.Save();
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

        public IHttpResponse CakeDetails(string idString)
        {
            int cakeId;

            if (!int.TryParse(idString, out cakeId) || !productRepository.ProductExists(cakeId))
            {
                return new ViewResponse(HttpStatusCode.NotFound, new NotFoundView());
            }

            var cake = productRepository.GetProductById(cakeId);

            return new ViewResponse(HttpStatusCode.OK, new CakeDetailsView(cake.Name, cake.Price, cake.ImagePath));
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