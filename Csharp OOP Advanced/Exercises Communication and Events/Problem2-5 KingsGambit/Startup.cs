using Problem2_5_KingsGambit.Models;
using Problem2_5_KingsGambit.Models.Contracts;
using System;
using System.Linq;

namespace Problem2_5_KingsGambit
{
    class Startup
    {
        private static void Main(string[] args)
        {
            SoldierList soldiers = new SoldierList();
            King king = new King(Console.ReadLine());

            string[] royalGuardNames = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var name in royalGuardNames)
            {
                RoyalGuard rg = new RoyalGuard(name);
                rg.SoldierDead += soldiers.HandleDeadSoldier;
                rg.SoldierDead += king.OnSoldierDeath;
                soldiers.Add(rg);
                king.KingAttacked += rg.OnKingAttack;
            }

            string[] footmanNames = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
            foreach (var name in footmanNames)
            {
                Footman fm = new Footman(name);
                fm.SoldierDead += soldiers.HandleDeadSoldier;
                fm.SoldierDead += king.OnSoldierDeath;
                soldiers.Add(fm);
                king.KingAttacked += fm.OnKingAttack;
            }

            string command = string.Empty;

            while ((command = Console.ReadLine()) != "End")
            {
                var tokens = command.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (tokens[0] == "Attack")
                {
                    king.RespondToAttack();
                }
                else if (tokens[0] == "Kill")
                {
                    string name = tokens[1];
                    IDefender soldier = soldiers.First(x => x.Name == name);
                    soldier.TakeAttack();
                }
            }
        }
    }
}