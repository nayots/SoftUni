using MiniServer.Server.Contracts;
using MiniServer.Server.Enums;
using MiniServer.Server.HTTP.Contracts;
using System.Text;

namespace MiniServer.Server.HTTP.Response
{
    public abstract class HttpResponse : IHttpResponse
    {
        private readonly IView view;

        protected HttpResponse(string redirectUrl)
        {
            this.HeaderCollection = new HttpHeaderCollection();
            this.CookieCollection = new HttpCookieCollection();
            this.StatusCode = HttpStatusCode.Found;
            this.AddHeader("Location", redirectUrl);
        }

        protected HttpResponse(HttpStatusCode responseCode, IView view)
        {
            this.HeaderCollection = new HttpHeaderCollection();
            this.CookieCollection = new HttpCookieCollection();
            this.view = view;
            this.StatusCode = responseCode;
        }

        public void AddHeader(string key, string value)
        {
            this.HeaderCollection.Add(new HttpHeader(key, value));
        }

        public IHttpHeaderCollection HeaderCollection { get; set; }
        public IHttpCookieCollection CookieCollection { get; set; }
        public HttpStatusCode StatusCode { get; set; }
        public string StatusMessage => this.StatusCode.ToString();

        public byte[] Data { get; private set; }

        public string Response
        {
            get
            {
                StringBuilder response = new StringBuilder();

                response.AppendLine($"HTTP/1.1 {(int)this.StatusCode} {StatusMessage}");

                response.AppendLine(this.HeaderCollection.ToString());
                response.AppendLine();

                if ((int)this.StatusCode < 300 | (int)this.StatusCode > 400)
                {
                    response.AppendLine(this.view.View());
                }

                return response.ToString();
            }
        }
    }
}