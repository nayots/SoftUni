using TrafficLights.Models.Enums;

namespace TrafficLights.Interfaces
{
    public interface ITrafficLight
    {
        Light Light { get; }

        void Cycle();
    }
}