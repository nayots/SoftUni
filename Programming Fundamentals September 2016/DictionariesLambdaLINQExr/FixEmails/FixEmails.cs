using System;
using System.Collections.Generic;
using System.Linq;
//04. Fix Emails
namespace FixEmails
{
    public class FixEmails
    {
        static void Main(string[] args)
        {
            bool canContinue = true;
            Dictionary<string, string> eMails = new Dictionary<string, string>();

            while (canContinue)
            {
                string name = Console.ReadLine();
                string emailAdress = "";
                if (name == "stop")
                {
                    canContinue = false;
                    break;
                }
                else
                {
                    emailAdress = Console.ReadLine();
                }

                bool isUsUkEmail = false;
                string mailTL = emailAdress.ToLower();

                if (emailAdress.Contains(".us") || emailAdress.Contains(".uk"))
                {
                    isUsUkEmail = true;
                }

                if (isUsUkEmail == false)
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
            }
            foreach (KeyValuePair<string,string> entry in eMails)
            {
                Console.WriteLine($"{entry.Key} -> {entry.Value}");
            }
        }
    }
}
