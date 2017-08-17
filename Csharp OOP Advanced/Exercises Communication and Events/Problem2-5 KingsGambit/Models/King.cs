using Problem2_5_KingsGambit.Models.Contracts;
using System;

namespace Problem2_5_KingsGambit.Models
{
    public delegate void KingUnderAttackEventHandler(object sender, EventArgs args);

    public delegate void DeathEventHandler(object sender, SoldierArgs args);

    public class King : IHuman
    {
        public event KingUnderAttackEventHandler KingAttacked;

        public King(string name)
        {
            this.Name = name;
        }

        public string Name { get; set; }

        public void RespondToAttack()
        {
            Console.WriteLine($"King {this.Name} is under attack!");
            OnKingAttacked(new EventArgs());
        }

        protected void OnKingAttacked(EventArgs args)
        {
            KingAttacked?.Invoke(this, args);
        }

        public void OnSoldierDeath(object sender, SoldierArgs args)
        {
            this.KingAttacked -= args.OnKingAttack;
        }
    }
}