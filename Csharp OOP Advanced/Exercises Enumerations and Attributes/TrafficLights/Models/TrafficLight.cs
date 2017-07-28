using System;
using TrafficLights.Interfaces;
using TrafficLights.Models.Enums;

namespace TrafficLights.Models
{
    public class TrafficLight : ITrafficLight
    {
        public TrafficLight(string light)
        {
            this.Light = (Light)Enum.Parse(typeof(Light), light);
        }

        public Light Light { get; private set; }

        public void Cycle()
        {
            this.Light += 1;

            if ((int)this.Light > 2)
            {
                this.Light = 0;
            }
        }

        public override string ToString()
        {
            return $"{this.Light}";
        }
    }
}