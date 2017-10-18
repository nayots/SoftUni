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
    public class UserController
    {
        private IUserRepository userRepository;

        public UserController()
        {
            this.userRepository = new UserRepository(new ShopDbContext());
        }

        public UserController(IUserRepository userRepository)
        {
            this.userRepository = userRepository;
        }

        public IHttpResponse LoginGet()
        {
            return new ViewResponse(HttpStatusCode.OK, new LoginView());
        }

        public IHttpResponse LoginPost(IHttpRequest req)
        {
            if (
                (req.FormData.ContainsKey("username") &&
                req.FormData.ContainsKey("password"))
                &&
                (!string.IsNullOrEmpty(req.FormData["username"].Trim()) &&
                !string.IsNullOrEmpty(req.FormData["password"].Trim()))
                )
            {
                string username = req.FormData["username"].Trim();
                string password = req.FormData["password"].Trim();

                if (userRepository.ValidateCredentials(username, password))
                {
                    req.Session.Add(SessionStore.CurrentUserKey, username);

                    return new RedirectResponse("/");
                }
                else
                {
                    if (!userRepository.UserExists(username))
                    {
                        return new RedirectResponse("/register");
                    }

                    return new ViewResponse(HttpStatusCode.OK, new LoginView("Red", LoginView.UsernameAndPasswordIncorrect));
                }
            }
            else
            {
                return new ViewResponse(HttpStatusCode.OK, new LoginView("Red", LoginView.UsernameAndPasswordReq));
            }
        }

        public IHttpResponse ProfileGet(IHttpSession session)
        {
            string nameOfCurrentUser = session.Get<string>(SessionStore.CurrentUserKey);

            var currentUser = userRepository.GetUserByUsername(nameOfCurrentUser);

            return new ViewResponse(HttpStatusCode.OK, new ProfileView(currentUser.Username, currentUser.RegistrationDate, currentUser.Orders.Count));
        }

        public IHttpResponse Logout(IHttpRequest request)
        {
            request.Session.Clear();

            return new RedirectResponse("/");
        }

        public IHttpResponse RegisterPost(IHttpRequest request)
        {
            if (request.FormData.ContainsKey("username") && request.FormData.ContainsKey("password1") && request.FormData.ContainsKey("password2"))
            {
                string username = request.FormData["username"].Trim();
                username = username.Replace(" ", string.Empty);
                string pass1 = request.FormData["password1"];
                string pass2 = request.FormData["password2"];

                string errorMessage = string.Empty;

                if (username.Length < 3 || (pass1 != pass2))
                {
                    errorMessage = "Invalid username or password!";

                    return new ViewResponse(HttpStatusCode.OK, new RegisterView(errorMessage));
                }
                if (userRepository.UserExists(username))
                {
                    errorMessage = "Username is taken!";

                    return new ViewResponse(HttpStatusCode.OK, new RegisterView(errorMessage));
                }

                var user = new User(username, pass1, DateTime.UtcNow);

                userRepository.AddUser(user);
                userRepository.Save();

                request.Session.Add(SessionStore.CurrentUserKey, username);
            }

            return new RedirectResponse("/");
        }

        public IHttpResponse RegisterGet()
        {
            return new ViewResponse(HttpStatusCode.OK, new RegisterView());
        }
    }
}