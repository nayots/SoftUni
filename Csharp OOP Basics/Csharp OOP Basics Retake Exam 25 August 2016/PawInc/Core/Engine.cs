using PawInc.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawInc.Core
{
    public class Engine
    {
        private CenterManager manager;

        public Engine()
        {
            this.manager = new CenterManager();
        }

        public void Run()
        {
            var input = string.Empty;

            while ((input = Console.ReadLine()) != "Paw Paw Pawah")
            {
                var tokens = input.Split(new string[] { " | " }, StringSplitOptions.RemoveEmptyEntries);
                var command = tokens[0];

                switch (command)
                {
                    case "RegisterCleansingCenter":
                        manager.RegisterCleansingCenter(tokens[1]);
                        break;

                    case "RegisterAdoptionCenter":
                        manager.RegisterAdoptionCenter(tokens[1]);
                        break;

                    case "RegisterCastrationCenter":
                        manager.RegisterCastrationCenter(tokens[1]);
                        break;

                    case "RegisterDog":
                        manager.RegisterDog(tokens[1], int.Parse(tokens[2]), int.Parse(tokens[3]), tokens[4]);
                        break;

                    case "RegisterCat":
                        manager.RegisterCat(tokens[1], int.Parse(tokens[2]), int.Parse(tokens[3]), tokens[4]);
                        break;

                    case "SendForCleansing":
                        manager.SendForCleansing(tokens[1], tokens[2]);
                        break;

                    case "SendForCastration":
                        manager.SendForCastration(tokens[1], tokens[2]);
                        break;

                    case "Cleanse":
                        manager.Cleanse(tokens[1]);
                        break;

                    case "Castrate":
                        manager.Castrate(tokens[1]);
                        break;

                    case "CastrationStatistics":
                        manager.CastrationStatistics();
                        break;

                    case "Adopt":
                        manager.Adopt(tokens[1]);
                        break;

                    default:
                        break;
                }
            }

            Console.Write(manager.ToString());
        }
    }
}