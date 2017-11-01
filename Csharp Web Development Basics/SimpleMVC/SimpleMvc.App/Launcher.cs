namespace SimpleMvc.App
{
    using SimpleMvc.App.Data;
    using SimpleMvc.Framework;
    using SimpleMvc.Framework.Routers;
    using System;
    using WebServer;

    class Launcher
    {
        static Launcher()
        {
            using (var db = new GameStoreDbContext())
            {
                db.Database.EnsureCreated();
            }
        }

        private static void Main(string[] args)
        {
            MvcEngine.Run(new WebServer(1337, new ControllerRouter(), new ResourceRouter()));
        }
    }
}