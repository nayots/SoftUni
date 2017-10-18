using MiniServer.Server.Enums;
using MiniServer.Server.Handlers;
using MiniServer.Server.HTTP;
using MiniServer.Server.HTTP.Contracts;
using MiniServer.Server.HTTP.Response;
using MiniServer.Server.Routing.Contracts;
using System;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace MiniServer.Server
{
    public class ConnectionHandler
    {
        private readonly Socket client;

        private readonly IServerRouteConfig serverRouteConfig;

        public ConnectionHandler(Socket client, IServerRouteConfig serverRouteConfig)
        {
            this.client = client;
            this.serverRouteConfig = serverRouteConfig;
        }

        public async Task ProcessRequestAsync()
        {
            string request = await this.ReadRequest();

            if (string.IsNullOrEmpty(request) || string.IsNullOrWhiteSpace(request))
            {
                this.client.Shutdown(SocketShutdown.Both);
                return;
            }

            IHttpContext httpContext = new HttpContext(request);

            IHttpResponse response = new HttpHandler(this.serverRouteConfig).Handle(httpContext);

            ArraySegment<byte> toBytes = new ArraySegment<byte>(Encoding.ASCII.GetBytes(response.Response));

            await this.client.SendAsync(toBytes, SocketFlags.None);
            if (response is ImageResponse && response.StatusCode == HttpStatusCode.OK)
            {
                await this.client.SendAsync(response.Data, SocketFlags.None);
            }

            Console.WriteLine("-----REQUEST-----");
            Console.WriteLine(request);
            Console.WriteLine("-----RESPONSE-----");
            Console.WriteLine(response.Response);

            this.client.Shutdown(SocketShutdown.Both);
        }

        private async Task<string> ReadRequest()
        {
            string request = string.Empty;
            ArraySegment<byte> data = new ArraySegment<byte>(new byte[1024]);

            int numBytesRead;

            while ((numBytesRead = await this.client.ReceiveAsync(data, SocketFlags.None)) > 0)
            {
                request += Encoding.ASCII.GetString(data.Array, 0, numBytesRead);
                if (numBytesRead < 1023)
                {
                    break;
                }
            }

            return request;
        }
    }
}