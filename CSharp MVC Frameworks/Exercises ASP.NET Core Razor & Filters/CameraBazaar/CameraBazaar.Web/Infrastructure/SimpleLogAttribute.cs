using Microsoft.AspNetCore.Mvc.Filters;
using System;
using System.IO;

namespace CameraBazaar.Web.Infrastructure
{
    public class SimpleLogAttribute : IActionFilter
    {
        private const string LogFilePath = "log.txt";

        public void OnActionExecuted(ActionExecutedContext context)
        {
            using (var sr = new StreamWriter(LogFilePath, true))
            {
                var dateAndTime = DateTime.UtcNow;
                var ipAddress = context.HttpContext.Connection.RemoteIpAddress;
                var userName = context.HttpContext.User?.Identity?.Name ?? "Anonymous";
                var controller = context.Controller.GetType().Name;
                var action = context.RouteData.Values["action"].ToString();

                var log = $"{dateAndTime} – {ipAddress} – {userName} – {controller}.{action}";

                if (context.Exception != null)
                {
                    log = $"[!] {log} – {context.Exception.GetType().Name} – {context.Exception.Message}";
                }

                sr.WriteLine(log);
            }
        }

        public void OnActionExecuting(ActionExecutingContext context)
        {
            return;
        }
    }
}