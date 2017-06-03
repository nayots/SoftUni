using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace Problem9_HTTPServer
{
    class HTTPServer
    {
        private static void Main(string[] args)
        {
            int port = 8080;
            TcpListener listener = new TcpListener(IPAddress.Any, port);

            try
            {
                listener.Start();
                while (true)
                {
                    Console.WriteLine("Listening...");
                    TcpClient client = listener.AcceptTcpClient();
                    StreamReader sr = new StreamReader(client.GetStream());
                    StreamWriter sw = new StreamWriter(client.GetStream());

                    string msg = "";

                    try
                    {
                        string request = sr.ReadLine();
                        Console.WriteLine(request);
                        string[] tokens = request.Split(' ');
                        string page = tokens[1];
                        using (sw)
                        {
                            if (page == "/")
                            {
                                sw.WriteLine("HTTP/1.0 200 OK\n");
                                msg = "<!doctype html> <html> <head> <title>Home Page</title> </head> <body> <h1>Welcome to our test page.</h1> <h4>You can check the server information <a href=\"/info\">here</a></h4> </body> </html>";
                                sw.Write(msg);
                            }
                            else if (page == "/info")
                            {
                                sw.WriteLine("HTTP/1.0 200 OK\n");
                                var ci = new CultureInfo("en-US");

                                msg = string.Format("<!doctype html> <html> <head> <title>Info Page</title> </head> <body> <h2>Current Time: {0}</h2> <h2>Logical Processors: {1}</h2><h4>Back to the <a href=\"/\">homepage</a></h4> </body> </html>", DateTime.Now.ToString("dd MMM yyyy HH:mm:ss", ci), Environment.ProcessorCount);
                                sw.Write(msg);
                            }
                            else
                            {
                                sw.WriteLine("HTTP/1.0 200 OK\n");
                                msg = string.Format("<!doctype html> <html> <head> <title>Error Page</title> </head> <body> <h2 style=\"color: red\">Error! Try going to the <a href=\" / \">home page</a></h2> </body> </html>");
                                sw.Write(msg);
                            }
                        }
                    }
                    catch (Exception e)
                    {
                        using (sw)
                        {
                            sw.WriteLine("HTTP/1.0 404 OK\n");
                            Console.WriteLine($"Exception: {e.Message}");
                        }
                    }

                    Console.WriteLine("Response sent.");
                }
            }
            catch (WebException ex)
            {
                Console.WriteLine(ex.Status);
            }
        }
    }
}