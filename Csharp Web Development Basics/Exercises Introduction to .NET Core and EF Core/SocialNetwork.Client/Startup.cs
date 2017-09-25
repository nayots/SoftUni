using Microsoft.EntityFrameworkCore;
using SocialNetwork.Client.Core;
using SocialNetwork.Data;

namespace SocialNetwork.Client
{
    class Startup
    {
        private static void Main(string[] args)
        {
            /*
             * Change the connection string if you are not using SQL EXPRESS,
             * also EF7 does not support custom Validation Attributes(for now) so keep that in mind when looking around.
             */

            using (var db = new SocialNetworkContext())
            {
                db.Database.Migrate();

                var engine = new Engine();

                engine.Run();
            }
        }
    }
}