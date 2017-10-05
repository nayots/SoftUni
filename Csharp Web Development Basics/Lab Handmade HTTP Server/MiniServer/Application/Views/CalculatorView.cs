using MiniServer.Server.Contracts;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace MiniServer.Application.Views
{
    public class CalculatorView : IView
    {
        public static string lastResult;
        private const string ReplacementSnip = "<!--replace-->";

        public string View()
        {
            string html = File.ReadAllText(@".\Application\Resources\calculator.html");

            if (!string.IsNullOrEmpty(lastResult))
            {
                string resultHtml = $"<p>Result: {lastResult}</p>";

                html = html.Replace(ReplacementSnip, resultHtml);

                lastResult = string.Empty;
            }

            return html;
        }
    }
}