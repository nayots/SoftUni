using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TeamBuilder.Client.Core.Commands
{
    public class ExitCommand
    {
        public void Execute(string[] data)
        {
            if (data.Count() != 0)
            {
                throw new FormatException("Invalid arguments count!");
            }

            Environment.Exit(0);
        }
    }
}
