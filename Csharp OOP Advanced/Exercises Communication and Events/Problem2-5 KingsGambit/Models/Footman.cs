using Problem2_5_KingsGambit.Models.Contracts;
using System;

namespace Problem2_5_KingsGambit.Models
{
    public class Footman : IDefender
    {
        public event DeathEventHandler SoldierDead;

        public Footman(string name)
        {
            this.Name = name;
            this.Lives = 2;
        }

        public string Name { get; protected set; }

        public int Lives { get; protected set; }

        public void OnKingAttack(object sender, EventArgs args)
        {
            Console.WriteLine($"Footman {this.Name} is panicking!");
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