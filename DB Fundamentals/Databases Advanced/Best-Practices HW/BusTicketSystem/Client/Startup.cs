using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    class Startup
    {
        static void Main(string[] args)
        {

            CommandDispatcher commandDispatcher = new CommandDispatcher();

            Engine engine = new Engine(commandDispatcher);

            engine.Run();

            //This solution contains problem 3* and 4** of the Best Practices HomeWork
            //Server is .\SQLEXPRESS
            //input is case sensitive
        }
    }
}
