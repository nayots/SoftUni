using Problem2_5_KingsGambit.Models.Contracts;
using System.Collections.Generic;

namespace Problem2_5_KingsGambit.Models
{
    public class SoldierList : List<IDefender>
    {
        public void HandleDeadSoldier(object sender, SoldierArgs args)
        {
            this.Remove(args.Soldier);
        }
    }
}