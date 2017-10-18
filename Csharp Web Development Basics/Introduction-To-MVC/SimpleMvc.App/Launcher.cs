using SimpleMvc.Data;
using SimpleMvc.Framework;
using SimpleMvc.Framework.Routers;

namespace SimpleMvc.App
{
    class Launcher
    {
        private static void Main(string[] args)
        {
            using (var db = new NotesDbContext())
            {
                db.Database.EnsureCreated();
            }

            var server = new WebServer.WebServer(8000, new ControllerRouter());

            MvcEngine.Run(server);
        }
    }
}