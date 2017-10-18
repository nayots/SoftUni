using MiniServer.Application;
using MiniServer.Data;
using MiniServer.Server;
using MiniServer.Server.Contracts;
using MiniServer.Server.Routing;
using MiniServer.Server.Routing.Contracts;

namespace MiniServer
{
    class Launcher : IRunnable
    {
        private WebServer webServer;

        private static void Main()
        {
            using (var db = new ShopDbContext())
            {
                db.Database.EnsureCreated();
            }

            new Launcher().Run();
        }

        public void Run()
        {
            IApplication app = new MainApplication();
            IAppRouteConfig routeConfig = new AppRouteConfig();
            app.Start(routeConfig);

            this.webServer = new WebServer(8230, routeConfig);
            this.webServer.Run();
        }
    }
}