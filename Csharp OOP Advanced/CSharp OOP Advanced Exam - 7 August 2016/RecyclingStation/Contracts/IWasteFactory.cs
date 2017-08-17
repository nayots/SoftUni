using RecyclingStation.WasteDisposal.Interfaces;

namespace RecyclingStation
{
    public interface IWasteFactory
    {
        IWaste Create(string name, double weight, double volumePerKg, string type);
    }
}