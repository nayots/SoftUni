using InfernoInfinity.Core.Factories;
using InfernoInfinity.Interfaces;
using InfernoInfinity.Models.Attributes;
using InfernoInfinity.Models.Weapons;
using System;
using System.Collections.Generic;
using System.Linq;

namespace InfernoInfinity.Core
{
    public class CommandDispatcher : ICommandDispatcher
    {
        private OutputHandler outHandler;
        private InputHandler inHandler;
        private IList<IWeapon> weapons;
        private WeaponFactory weaponFactory;
        private GemFactory gemFactory;
        private WeaponAttribute weaponAttribute;

        public CommandDispatcher()
        {
            this.outHandler = new OutputHandler();
            this.weapons = new List<IWeapon>();
            this.inHandler = new InputHandler();
            this.weaponFactory = new WeaponFactory();
            this.gemFactory = new GemFactory();
            this.weaponAttribute = (WeaponAttribute)typeof(Weapon).GetCustomAttributes(true).First();
        }

        public void ExecuteCommand(IList<string> tokens)
        {
            IWeapon currentWeapon = null;
            IBaseGem currentGem = null;

            string commandName = tokens[0];

            switch (commandName)
            {
                case "Create":
                    List<string> weaponInfo = inHandler.SplitInput(tokens[1], " ");
                    weaponInfo.Add(tokens[2]);
                    this.weapons.Add(this.weaponFactory.Create(weaponInfo));
                    break;

                case "Add":
                    currentWeapon = GetWeapon(tokens[1]);
                    currentGem = this.gemFactory.Create(inHandler.SplitInput(tokens[3], " "));

                    currentWeapon.AddGem(int.Parse(tokens[2]), currentGem);
                    break;

                case "Remove":
                    currentWeapon = GetWeapon(tokens[1]);
                    currentWeapon.RemoveGem(int.Parse(tokens[2]));
                    break;

                case "Print":
                    currentWeapon = GetWeapon(tokens[1]);
                    outHandler.PrintLine(currentWeapon.ToString());
                    break;

                case "Author":
                    outHandler.PrintLine(weaponAttribute.PrintInfo("Author"));
                    break;

                case "Revision":
                    outHandler.PrintLine(weaponAttribute.PrintInfo("Revision"));
                    break;

                case "Description":
                    outHandler.PrintLine(weaponAttribute.PrintInfo("Description"));
                    break;

                case "Reviewers":
                    outHandler.PrintLine(weaponAttribute.PrintInfo("Reviewers"));
                    break;

                default:
                    throw new InvalidOperationException($"Command not available: {commandName}");
            }
        }

        private IWeapon GetWeapon(string weaponName)
        {
            return this.weapons.Where(w => w.WeaponName == weaponName).First();
        }
    }
}