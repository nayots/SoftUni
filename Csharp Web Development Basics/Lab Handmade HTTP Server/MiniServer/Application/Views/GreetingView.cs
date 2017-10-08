using MiniServer.Server.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniServer.Server.HTTP.Contracts;

namespace MiniServer.Application.Views
{
    public class GreetingView : IView
    {
        private IHttpSession session;

        public GreetingView(IHttpSession session)
        {
            this.session = session;
        }

        public string View()
        {
            string result = string.Empty;

            if (this.session.Get("firstName") == null)
            {
                result =
                    "<h2>Please fulfill the required items</h2>" +
                    "<form method=\"post\">" +
                    "<label>First Name:</label> <input type=\"text\" name=\"firstName\"/>" +
                    "<input type=\"submit\" value=\"Next\"/>" +
                    "</form>";
            }
            else if (this.session.Get("lastName") == null)
            {
                result =
                    "<h2>Please fulfill the required items</h2>" +
                    "<form method=\"post\">" +
                    "<label>Last Name:</label> <input type=\"text\" name=\"lastName\"/>" +
                    "<input type=\"submit\" value=\"Next\"/>" +
                    "</form>";
            }
            else if (this.session.Get("age") == null)
            {
                result =
                    "<h2>Please fulfill the required items</h2>" +
                    "<form method=\"post\">" +
                    "<label>Age:</label> <input type=\"number\" name=\"age\"/>" +
                    "<input type=\"submit\" value=\"Next\"/>" +
                    "</form>";
            }
            else
            {
                string fName = this.session.Get<string>("firstName");
                string lName = this.session.Get<string>("lastName");
                string age = this.session.Get<string>("age");

                result = $"<h2>Hello {fName} {lName} at age {age}</h2>";
            }

            return result;
        }
    }
}