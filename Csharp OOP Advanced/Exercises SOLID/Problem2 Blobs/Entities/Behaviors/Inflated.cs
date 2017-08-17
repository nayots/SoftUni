using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace _02.Blobs.Entities.Behaviors
{
    public class Inflated : Behavior
    {
        public override void ApplyRecurrentEffect(Blob source)
        {
            source.Health -= 10;
        }

        public override void ApplyTriggerEffect(Blob source)
        {
            source.Health += 50;
        }

        public override void Trigger(Blob source)
        {
            this.IsTriggered = true;
            this.ApplyTriggerEffect(source);
        }
    }
}