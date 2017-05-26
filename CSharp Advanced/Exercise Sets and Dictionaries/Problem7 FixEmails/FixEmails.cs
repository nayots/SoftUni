using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem7_FixEmails
{
    class FixEmails
    {
        static void Main(string[] args)
        {
            Dictionary<string, string> eMails = new Dictionary<string, string>();
            string name = Console.ReadLine();

            while (name != "stop")
            {
                string emailAdress = Console.ReadLine();

                if (!emailAdress.Contains(".us") && !emailAdress.Contains(".uk"))
                {
                    if (eMails.ContainsKey(name))
                    {
                        eMails[name] = emailAdress;
                    }
                    else
                    {
                        eMails.Add(name, emailAdress);
                    }
                }
                name = Console.ReadLine();
            }
            foreach (KeyValuePair<string, string> entry in eMails)
            {
                Console.WriteLine($"{entry.Key} -> {entry.Value}");
            }
        }
    }
}
