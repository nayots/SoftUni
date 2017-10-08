using MiniServer.Application.Models;
using MiniServer.Application.Views;
using MiniServer.Server.Enums;
using MiniServer.Server.HTTP;
using MiniServer.Server.HTTP.Contracts;
using MiniServer.Server.HTTP.Response;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq.Expressions;
using System.Text;
using System.Text.RegularExpressions;

namespace MiniServer.Application.Controllers
{
    public class HomeController
    {
        private static string CorrectUsername = "suAdmin";
        private static string CorrectPassword = "aDminPwn17";

        public IHttpResponse Index()
        {
            var response = new ViewResponse(HttpStatusCode.OK, new HomeIndexView());

            response.CookieCollection.Add(new HttpCookie("lang", "en"));

            return response;
        }

        public IHttpResponse Image(string imagePath)
        {
            return new ImageResponse(imagePath);
        }

        public IHttpResponse AboutUs()
        {
            return new ViewResponse(HttpStatusCode.OK, new AboutUsView());
        }

        public IHttpResponse AddPost(string name, double price)
        {
            name = name.Replace(",", string.Empty).Trim();
            if (!string.IsNullOrEmpty(name) && !string.IsNullOrWhiteSpace(name))
            {
                CakeList.Add(new Cake(name, price));
            }

            return new RedirectResponse($"/add");
        }

        public IHttpResponse AddGet()
        {
            return new ViewResponse(HttpStatusCode.OK, new AddView());
        }

        public IHttpResponse SearchGet(IDictionary<string, string> queryParams)
        {
            string cakeName = string.Empty;

            if (queryParams.ContainsKey("name"))
            {
                cakeName = queryParams["name"];
            }

            return new ViewResponse(HttpStatusCode.OK, new SearchView(cakeName));
        }

        public IHttpResponse CalculatorGet()
        {
            return new ViewResponse(HttpStatusCode.OK, new CalculatorView());
        }

        public IHttpResponse CalculatorPost(string value1, string sign, string value2)
        {
            try
            {
                double value1Num = double.Parse(value1.Trim());
                double value2Num = double.Parse(value2.Trim());

                sign = sign.Trim();

                if (sign != "*" || sign != "/" || sign != "+" || sign != "-")
                {
                    CalculatorView.lastResult = "Invalid Sign";
                }

                double result;

                switch (sign)
                {
                    case "+":
                        result = value1Num + value2Num;
                        break;

                    case "-":
                        result = value1Num - value2Num;
                        break;

                    case "*":
                        result = value1Num * value2Num;
                        break;

                    case "/":
                        result = value1Num / value2Num;
                        break;

                    default:
                        throw new ArgumentException();
                }

                CalculatorView.lastResult = result.ToString();
            }
            catch (Exception)
            {
                CalculatorView.lastResult = "Invalid Expression";
            }

            return new RedirectResponse("/calculator");
        }

        public IHttpResponse LoginPost(IDictionary<string, string> formArgs)
        {
            if (formArgs.ContainsKey("username") && formArgs.ContainsKey("password"))
            {
                string username = formArgs["username"];
                string password = formArgs["password"];

                if (username.Trim() == CorrectUsername && password.Trim() == CorrectPassword)
                {
                    LoginView.isAdmin = true;
                }
                LoginView.hasPost = true;
            }
            else if (formArgs.ContainsKey("to") && formArgs.ContainsKey("subject") && formArgs.ContainsKey("message"))
            {
                string recipient = formArgs["to"];
                string subject = formArgs["subject"];
                string message = formArgs["message"];

                LoginView.emailSent = true;

                if (CheckEmail(recipient, subject, message))
                {
                    LoginView.emailIsValid = true;
                }
            }

            return new RedirectResponse("/login");
        }

        public IHttpResponse GreetingGet(IHttpRequest req)
        {
            return new ViewResponse(HttpStatusCode.OK, new GreetingView(req.Session));
        }

        public IHttpResponse GreetingPost(IHttpRequest req)
        {
            if (req.Session.Get("firstName") != null)
            {
                if (req.Session.Get("lastName") != null)
                {
                    if (req.Session.Get("age") == null)
                    {
                        req.Session.Add("age", req.FormData["age"]);
                    }
                }
                else
                {
                    string lastNameValue = req.FormData["lastName"];
                    req.Session.Add("lastName", lastNameValue);
                }
            }
            else
            {
                string firstNameValue = req.FormData["firstName"];
                req.Session.Add("firstName", firstNameValue);
            }

            return new RedirectResponse("/greeting");
        }

        private bool CheckEmail(string recipient, string subject, string message)
        {
            Regex rgx = new Regex(@"^([a-zA-Z0-9]+[.-_]?[a-zA-Z0-9]+)(@)[a-zA-Z0-9]+(\.[a-zA-Z0-9]{2,})+$");

            if (!rgx.IsMatch(recipient))
            {
                return false;
            }
            if (subject.Length > 100)
            {
                return false;
            }

            return true;
        }

        public IHttpResponse LoginGet()
        {
            return new ViewResponse(HttpStatusCode.OK, new LoginView());
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