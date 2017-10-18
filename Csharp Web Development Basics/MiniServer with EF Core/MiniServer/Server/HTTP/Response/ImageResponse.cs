using MiniServer.Server.Enums;
using MiniServer.Server.HTTP.Contracts;
using System.IO;
using System.Text;

namespace MiniServer.Server.HTTP.Response
{
    public class ImageResponse : IHttpResponse
    {
        private string imagePath;

        public ImageResponse(string imagepath)
        {
            this.imagePath = imagepath;
            this.HeaderCollection = new HttpHeaderCollection();
            this.CookieCollection = new HttpCookieCollection();
        }

        public IHttpHeaderCollection HeaderCollection { get; private set; }

        public IHttpCookieCollection CookieCollection { get; private set; }

        public HttpStatusCode StatusCode { get; private set; }

        public string StatusMessage => this.StatusCode.ToString();

        public string Response
        {
            get
            {
                StringBuilder response = new StringBuilder();

                string filepath = $@".\Application\Resources\Images\{this.imagePath}";

                if (File.Exists(filepath))
                {
                    this.StatusCode = HttpStatusCode.OK;

                    response.AppendLine($"HTTP/1.1 {(int)this.StatusCode} {StatusMessage}");
                    if (!this.HeaderCollection.ContainsKey("Content-Type"))
                    {
                        this.AddHeader("Content-Type", "image/png,image/jpg,image");
                    }

                    byte[] imageData = File.ReadAllBytes(filepath);
                    if (!this.HeaderCollection.ContainsKey("Content-Length"))
                    {
                        this.AddHeader("Content-Length", $"{imageData.Length}");
                    }
                    this.Data = imageData;

                    response.Append(this.HeaderCollection.ToString());
                    response.AppendLine();
                }
                else
                {
                    this.StatusCode = HttpStatusCode.NotFound;

                    response.AppendLine($"HTTP/1.1 {(int)this.StatusCode} {StatusMessage}");

                    response.Append(this.HeaderCollection.ToString());
                    response.AppendLine();
                }

                return response.ToString();
            }
        }

        public byte[] Data { get; private set; }

        public void AddHeader(string key, string value)
        {
            this.HeaderCollection.Add(new HttpHeader(key, value));
        }
    }
}