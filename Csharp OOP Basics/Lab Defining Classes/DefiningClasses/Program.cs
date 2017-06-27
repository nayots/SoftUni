using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

class Startup
{
    private static void Main(string[] args)
    {
        List<BankAccount> accounts = new List<BankAccount>();

        var inpSc = new InputScanner();

        inpSc.Run(accounts);
    }
}