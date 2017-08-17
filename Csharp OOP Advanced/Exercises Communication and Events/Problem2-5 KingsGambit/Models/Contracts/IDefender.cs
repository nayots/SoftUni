using System;

namespace Problem2_5_KingsGambit.Models.Contracts
{
    public interface IDefender : IHuman
    {
        event DeathEventHandler SoldierDead;

        int Lives { get; }

        void OnKingAttack(object sender, EventArgs args);

        void TakeAttack();
    }
}