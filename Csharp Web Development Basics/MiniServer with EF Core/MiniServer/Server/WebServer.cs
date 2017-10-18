using MiniServer.Server.Contracts;
using MiniServer.Server.Routing;
using MiniServer.Server.Routing.Contracts;
using System;
using System.Net;
using System.Net.Sockets;
using System.Threading.Tasks;

namespace MiniServer.Server
{
    public class WebServer : IRunnable
    {
        private readonly int port;

        private readonly IServerRouteConfig serverRouteConfig;

        private readonly TcpListener tcpListener;

        private bool isRunning;

        public WebServer(int port, IAppRouteConfig routeConfig)
        {
            this.port = port;
            this.tcpListener = new TcpListener(IPAddress.Parse("127.0.0.1"), port);

            this.serverRouteConfig = new ServerRouteConfig(routeConfig);
        }

        public void Run()
        {
            this.tcpListener.Start();

            this.isRunning = true;

            Console.WriteLine($"Server started. Listening to TCP clients at 127.0.0.1:{port}");

            Task task = Task.Run(this.ListenLoop);

            task.Wait();
        }

        private async Task ListenLoop()
        {
            while (this.isRunning)
            {
                Socket client = await this.tcpListener.AcceptSocketAsync();
                ConnectionHandler connectionHandler = new ConnectionHandler(client, this.serverRouteConfig);
                Task connection = connectionHandler.ProcessRequestAsync();
                connection.Wait();
            }
        }
    }
}