using MiniServer.Application.Models;
using MiniServer.Application.Views;
using MiniServer.Server.Enums;
using MiniServer.Server.HTTP.Contracts;
using MiniServer.Server.HTTP.Response;

namespace MiniServer.Application.Controllers
{
    public class ShoppingController
    {
        public IHttpResponse Order(IHttpRequest req)
        {
            if (req.QueryParameters.ContainsKey("id"))
            {
                int id = int.Parse(req.QueryParameters["id"]);

                if (!req.Session.Contains("cart"))
                {
                    req.Session.Add("cart", new ShoppingCart());
                }

                var cart = req.Session.Get<ShoppingCart>("cart");

                var cake = CakeList.GetCakeById(id);

                if (cake != null)
                {
                    cart.Cakes.Add(cake);
                }
            }

            string returnPath = "/search";

            string returnUrl = req.QueryParameters["returnUrl"];

            if (!string.IsNullOrEmpty(returnUrl))
            {
                returnPath = $"{returnPath}?name={returnUrl}";
            }

            return new RedirectResponse(returnPath);
        }

        internal IHttpResponse CartGet(IHttpRequest request)
        {
            return new ViewResponse(HttpStatusCode.OK, new CartView(request));
        }

        internal IHttpResponse CartPost(IHttpRequest request)
        {
            var cart = request.Session.Get<ShoppingCart>("cart");

            if (cart is null || cart.Cakes.Count == 0)
            {
                return new ViewResponse(HttpStatusCode.OK, new CartView(request, "You have 0 items in your cart!"));
            }

            return new RedirectResponse("/success");
        }

        public IHttpResponse Success(IHttpRequest request)
        {
            var cart = request.Session.Get<ShoppingCart>("cart");

            if (cart == null)
            {
                return new ViewResponse(HttpStatusCode.OK, new SuccessView(false));
            }
            else
            {
                if (cart.Cakes.Count > 0)
                {
                    cart.Cakes.Clear();

                    return new ViewResponse(HttpStatusCode.OK, new SuccessView());
                }
                else
                {
                    return new ViewResponse(HttpStatusCode.OK, new SuccessView(false));
                }
            }
        }
    }
}