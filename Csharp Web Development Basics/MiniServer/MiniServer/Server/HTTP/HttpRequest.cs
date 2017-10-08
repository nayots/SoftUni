using MiniServer.Server.Enums;
using MiniServer.Server.Exceptions;
using MiniServer.Server.HTTP.Contracts;
using System;
using System.Collections.Generic;
using System.Net;

namespace MiniServer.Server.HTTP
{
    public class HttpRequest : IHttpRequest
    {
        public HttpRequest(string requestString)
        {
            this.HeaderCollection = new HttpHeaderCollection();
            this.Cookies = new HttpCookieCollection();
            this.UrlParameters = new Dictionary<string, string>();
            this.QueryParameters = new Dictionary<string, string>();
            this.FormData = new Dictionary<string, string>();

            this.ParseRequest(requestString);
        }

        public Dictionary<string, string> FormData { get; set; }

        public IHttpHeaderCollection HeaderCollection { get; private set; }

        public IHttpCookieCollection Cookies { get; private set; }

        public string Path { get; set; }

        public Dictionary<string, string> QueryParameters { get; set; }

        public HttpRequestMethod RequestMethod { get; set; }

        public string Url { get; set; }

        public Dictionary<string, string> UrlParameters { get; set; }

        public IHttpSession Session { get; set; }

        private void ParseRequest(string requestString)
        {
            string[] requestLines = requestString
                .Split(new[] { Environment.NewLine }, StringSplitOptions.None);

            string[] requestLine = requestLines[0].Trim()
                .Split(new[] { " " }, StringSplitOptions.RemoveEmptyEntries);

            if (requestLine.Length != 3 || requestLine[2].ToLower() != "http/1.1")
            {
                string message = $"Invalid request line";

                throw new BadRequestException(message);
            }

            this.RequestMethod = this.ParseRequestMethod(requestLine[0].ToUpper());
            this.Url = requestLine[1];
            this.Path = this.Url
                .Split(new[] { '?', '#' }, StringSplitOptions.RemoveEmptyEntries)[0];
            this.ParseHeaders(requestLines);
            this.ParseCookies();
            this.ParseParameters();

            if (this.RequestMethod == HttpRequestMethod.POST)
            {
                this.ParseQuery(requestLines[requestLines.Length - 1], this.FormData);
            }

            this.SetSession();
        }

        public void SetSession()
        {
            if (this.Cookies.ContainsKey(SessionStore.SessionCookieKey))
            {
                var cookie = this.Cookies.Get(SessionStore.SessionCookieKey);
                var sessionId = cookie.Value;

                this.Session = SessionStore.Get(sessionId);
            }
        }

        private void ParseCookies()
        {
            if (this.HeaderCollection.ContainsKey("Cookie"))
            {
                var cookiesList = this.HeaderCollection.GetHeader("Cookie");

                foreach (HttpHeader header in cookiesList)
                {
                    string cookieString = header.Value;
                    if (string.IsNullOrEmpty(cookieString))
                    {
                        return;
                    }
                    if (!cookieString.Contains("="))
                    {
                        continue;
                    }

                    string[] cookies = cookieString.Split(new char[] { ';' }, StringSplitOptions.RemoveEmptyEntries);

                    foreach (string c in cookies)
                    {
                        string[] cookieKeyAndValue = c.Split(new[] { '=' }, StringSplitOptions.RemoveEmptyEntries);

                        string key = cookieKeyAndValue[0].Trim();
                        string value = cookieKeyAndValue[1].Trim();

                        this.Cookies.Add(new HttpCookie(key, value, false));
                    }
                }
            }
        }

        private void ParseParameters()
        {
            if (!this.Url.Contains("?"))
            {
                return;
            }

            string query = this.Url.Split('?')[1];
            this.ParseQuery(query, this.QueryParameters);
        }

        private void ParseQuery(string query, Dictionary<string, string> queryParameters)
        {
            if (!query.Contains("="))
            {
                return;
            }

            string[] queryPairs = query.Split('&');
            foreach (var queryPair in queryPairs)
            {
                string[] queryArgs = queryPair.Split("=");
                if (queryArgs.Length != 2)
                {
                    continue;
                }

                queryParameters.Add(
                    WebUtility.UrlDecode(queryArgs[0]), WebUtility.UrlDecode(queryArgs[1]));
            }
        }

        private void ParseHeaders(string[] requestLines)
        {
            int endIndex = Array.IndexOf(requestLines, string.Empty);
            for (int i = 1; i < endIndex; i++)
            {
                string[] headerArgs = requestLines[i]
                    .Split(new[] { ": " }, StringSplitOptions.None);

                var header = new HttpHeader(headerArgs[0], headerArgs[1]);

                this.HeaderCollection.Add(header);
            }

            if (!this.HeaderCollection.ContainsKey("Host"))
            {
                throw new BadRequestException("Invalid request line");
            }
        }

        private HttpRequestMethod ParseRequestMethod(string requestMethodString)
        {
            try
            {
                HttpRequestMethod requestMethod = (HttpRequestMethod)Enum.Parse(typeof(HttpRequestMethod), requestMethodString);
                return requestMethod;
            }
            catch (Exception)
            {
                throw new BadRequestException("Invalid request line");
            }
        }

        public void AddUrlParameter(string key, string value)
        {
            this.UrlParameters[key] = value;
        }
    }
}