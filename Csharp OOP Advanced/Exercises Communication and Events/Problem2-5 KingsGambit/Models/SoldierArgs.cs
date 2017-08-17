using Problem2_5_KingsGambit.Models.Contracts;
using System;

namespace Problem2_5_KingsGambit.Models
{
    public class SoldierArgs : EventArgs
    {
        public SoldierArgs(IDefender soldier, KingUnderAttackEventHandler onKingAttack)
        {
            this.Soldier = soldier;
            this.OnKingAttack = onKingAttack;
        }

        public IDefender Soldier { get; private set; }

        public KingUnderAttackEventHandler OnKingAttack { get; private set; }
    }
}