using Problem2_5_KingsGambit.Models.Contracts;
using System;

namespace Problem2_5_KingsGambit.Models
{
    public class RoyalGuard : IDefender
    {
        public event DeathEventHandler SoldierDead;

        public RoyalGuard(string name)
        {
            this.Name = name;
            this.Lives = 3;
        }

        public string Name { get; protected set; }

        public int Lives { get; protected set; }

        public void OnKingAttack(object sender, EventArgs args)
        {
            Console.WriteLine($"Royal Guard {this.Name} is defending!");
        }

        public void TakeAttack()
        {
            this.Lives--;

            if (this.Lives <= 0)
            {
                OnDeath(new SoldierArgs(this, this.OnKingAttack));
            }
        }

        protected void OnDeath(SoldierArgs args)
        {
            SoldierDead?.Invoke(this, args);
        }
    }
}