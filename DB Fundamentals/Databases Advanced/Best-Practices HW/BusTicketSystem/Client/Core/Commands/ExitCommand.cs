using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Client
{
    public class ExitCommand
    {
        public void Execute()
        {
            Console.WriteLine("Thank you and good bye!");
            Environment.Exit(0);
        }
    }
}
