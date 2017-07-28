using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

[SoftUniAttribute("Ventsi")]
class StartUp
{
    [SoftUniAttribute("Gosho")]
    private static void Main(string[] args)
    {
        var tracker = new Tracker();
        tracker.PrintMethodsByAuthor();
    }
}