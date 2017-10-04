using MiniServer.Server.HTTP.Contracts;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using MiniServer.Server.Enums;
using System.IO;

namespace MiniServer.Server.HTTP.Response
{
    public class ImageResponse : IHttpResponse
    {
        private string imagePath;

        public ImageResponse(string imagepath)
        {
            this.imagePath = imagepath;
            this.HeaderCollection = new HttpHeaderCollection();
        }

        public HttpHeaderCollection HeaderCollection { get; private set; }

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
                    this.AddHeader("Content-Type", "image/png,image/jpg,image");

                    byte[] imageData = File.ReadAllBytes(filepath);
                    this.AddHeader("Content-Length", $"{imageData.Length}");
                    this.Data = imageData;

                    response.AppendLine(this.HeaderCollection.ToString());
                    response.AppendLine();
                }
                else
                {
                    this.StatusCode = HttpStatusCode.NotFound;

                    response.AppendLine($"HTTP/1.1 {(int)this.StatusCode} {StatusMessage}");

                    response.AppendLine(this.HeaderCollection.ToString());
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