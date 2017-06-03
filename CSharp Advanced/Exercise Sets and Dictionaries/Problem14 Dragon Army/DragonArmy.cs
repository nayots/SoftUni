using System;
using System.Collections.Generic;
using System.Linq;

namespace Problem14_Dragon_Army
{
    class DragonArmy
    {
        private static void Main(string[] args)
        {
            Dictionary<string, Dictionary<string, int[]>> dragonData = new Dictionary<string, Dictionary<string, int[]>>();
            int n = int.Parse(Console.ReadLine());

            for (int i = 0; i < n; i++)
            {
                string command = Console.ReadLine();//{type} {name} {damage} {health} {armor}.
                ManageInput(command, dragonData);
            }
            PrintResults(dragonData);
        }

        private static void PrintResults(Dictionary<string, Dictionary<string, int[]>> dragonData)
        {
            foreach (var type in dragonData)//{Type}::({damage}/{health}/{armor})
            {
                double avDmg = type.Value.Select(x => x.Value[0]).Average();
                double avHp = type.Value.Select(x => x.Value[1]).Average();
                double avArmor = type.Value.Select(x => x.Value[2]).Average();
                Console.WriteLine($"{type.Key}::({avDmg:f2}/{avHp:f2}/{avArmor:f2})");
                foreach (var dragon in type.Value.OrderBy(x => x.Key))
                {
                    //-{Name} -> damage: {damage}, health: {health}, armor: {armor}
                    Console.WriteLine("-{0} -> damage: {1}, health: {2}, armor: {3}"
                        , dragon.Key, dragon.Value[0], dragon.Value[1], dragon.Value[2]);
                }
            }
        }

        private static void ManageInput(string command, Dictionary<string, Dictionary<string, int[]>> dragonData)
        {
            string[] details = command.Split();
            string type = details[0];
            string name = details[1];

            int dmg = 45;//Default damage 45,health 250, and armor 10
            if (details[2] != "null")//Custom value
            {
                dmg = int.Parse(details[2]);
            }

            int hp = 250;
            if (details[3] != "null")
            {
                hp = int.Parse(details[3]);
            }

            int armor = 10;
            if (details[4] != "null")
            {
                armor = int.Parse(details[4]);
            }

            if (dragonData.ContainsKey(type))
            {
                if (dragonData[type].ContainsKey(name))
                {
                    dragonData[type][name][0] = dmg;
                    dragonData[type][name][1] = hp;
                    dragonData[type][name][2] = armor;
                }
                else
                {
                    dragonData[type].Add(name, new int[] { dmg, hp, armor });
                }
            }
            else
            {
                dragonData.Add(type, new Dictionary<string, int[]> { { name, new int[] { dmg, hp, armor } } });
            }
        }
    }
}