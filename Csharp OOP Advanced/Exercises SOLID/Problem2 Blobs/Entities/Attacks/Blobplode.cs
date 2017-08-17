using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Blobs.Entities.Attacks
{
    public class Blobplode : Attack
    {
        public override void Execute(Blob attacker, Blob target)
        {
            int hpLeft = attacker.Health - (attacker.Health / 2);
            if (hpLeft < 1)
            {
                hpLeft = 1;
            }
            attacker.Health = hpLeft;
            target.Respond(attacker.Damage * 2);
        }
    }
}