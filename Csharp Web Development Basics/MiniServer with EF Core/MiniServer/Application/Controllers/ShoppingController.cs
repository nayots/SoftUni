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
using System.Linq;

namespace MiniServer.Application.Controllers
{
    public class ShoppingController
    {
        private IProductRepository productRepository;
        private IOrderRepository orderRepository;
        private IUserRepository userRepository;

        public ShoppingController()
        {
            this.productRepository = new ProductRepository(new ShopDbContext());
            this.orderRepository = new OrderRepository(new ShopDbContext());
            this.userRepository = new UserRepository(new ShopDbContext());
        }

        public ShoppingController(IProductRepository productRepository, IOrderRepository orderRepository, IUserRepository userRepository)
        {
            this.productRepository = productRepository;
            this.orderRepository = orderRepository;
            this.userRepository = userRepository;
        }

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

                var cake = this.productRepository.GetProductById(id);

                if (cake != null)
                {
                    cart.Cakes.Add(cake);
                }
            }

            string returnPath = "/search";

            string returnUrl = string.Empty;

            if (req.QueryParameters.ContainsKey("returnUrl"))
            {
                returnUrl = req.QueryParameters["returnUrl"];
            }

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

        internal IHttpResponse OrderDetails(string orderIdString)
        {
            int orderId;

            if (!int.TryParse(orderIdString, out orderId) || !this.orderRepository.OrderExists(orderId))
            {
                return new ViewResponse(HttpStatusCode.NotFound, new NotFoundView());
            }

            var order = this.orderRepository.GetOrderById(orderId);

            var productsList = order.Products.Select(op => op.Product).ToList();

            return new ViewResponse(HttpStatusCode.OK, new OrderDetailsView(orderId, order.CreationDate, productsList));
        }

        public IHttpResponse Orders(IHttpRequest request)
        {
            var currentUserName = request.Session.Get<string>(SessionStore.CurrentUserKey);
            var currentUserId = this.userRepository.GetUserByUsername(currentUserName).Id;

            var orders = this.userRepository.GetUserOrders(currentUserId);

            return new ViewResponse(HttpStatusCode.OK, new OrdersView(orders));
        }

        public IHttpResponse Success(IHttpRequest request)
        {
            var cart = request.Session.Get<ShoppingCart>("cart");
            var currentUserName = request.Session.Get<string>(SessionStore.CurrentUserKey);
            var currentUserId = this.userRepository.GetUserByUsername(currentUserName).Id;

            if (cart == null)
            {
                return new ViewResponse(HttpStatusCode.OK, new SuccessView(false));
            }
            else
            {
                if (cart.Cakes.Count > 0)
                {
                    var order = new Order(DateTime.UtcNow, currentUserId);
                    this.orderRepository.AddOrder(order);

                    foreach (var cake in cart.Cakes)
                    {
                        order.Products.Add(new OrderProduct() { ProductId = cake.Id });
                    }
                    this.orderRepository.Save();

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