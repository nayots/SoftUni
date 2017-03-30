using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TeamBuilder.Client.Core;

namespace TeamBuilder.Client
{
    class Startup
    {
        static void Main(string[] args)
        {
            CommandDispatcher commandDispatcher = new CommandDispatcher();
            Engine engine = new Engine(commandDispatcher);
            engine.Run();

            //This solution contains the exercises from Lab1 and Lab2 from Big Overall Exercise Part I & II
        }
    }
}
