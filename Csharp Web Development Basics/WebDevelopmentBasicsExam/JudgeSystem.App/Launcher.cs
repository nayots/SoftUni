namespace JudgeSystem.App
{
    using JudgeSystem.App.Data;
    using JudgeSystem.App.Infrastructure;
    using JudgeSystem.App.Infrastructure.Mapping;
    using SimpleMvc.Framework;
    using SimpleMvc.Framework.Routers;
    using System;
    using WebServer;

    public class Launcher
    {
        static Launcher()
        {
            //PLEASE CHANGE THE CONNECTION STRING IF YOU ARE NOT USING SQL EXPRESS
            using (var db = new JudgeSystemDbContext())
            {
                //db.Database.EnsureDeleted();
                db.Database.EnsureCreated();
            }

            AutoMapperConfiguration.Initialize();
        }

        public static void Main()
            => MvcEngine.Run(
                new WebServer(1337,
                    DependencyControllerRouter.Get(),
                    new ResourceRouter()));
    }
}