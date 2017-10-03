using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace Problem3_SimpleWebServer
{
    class Startup
    {
        private static void Main(string[] args)
        {
            const int port = 1337;
            const string ip = "127.0.0.1";

            var ipAdr = IPAddress.Parse(ip);
            var listener = new TcpListener(ipAdr, port);
            listener.Start();

            Console.WriteLine($"Server started.");
            Console.WriteLine($"Listening to TCP clients at {ip}:{port}");

            Task.Run(async () => await Connect(listener))
                .GetAwaiter()
                .GetResult();
        }

        public static async Task Connect(TcpListener listener)
        {
            while (true)
            {
                Console.WriteLine("Waiting for client...");
                var client = await listener.AcceptTcpClientAsync();

                Console.WriteLine("Client connected");

                byte[] buffer = new byte[1024];
                await client.GetStream().ReadAsync(buffer, 0, buffer.Length);

                var message = Encoding.UTF8.GetString(buffer);

                Console.WriteLine(message.Trim('\0'));

                byte[] data = Encoding.UTF8.GetBytes("HTTP/1.1 200 OK\nContent-Type: text/plain\n\nHello from server!");
                await client.GetStream().WriteAsync(data, 0, data.Length);
                Console.WriteLine("Closing connection.");
                client.Dispose();
            }
        }
    }
}