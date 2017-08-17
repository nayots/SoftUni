using RecyclingStation.WasteDisposal.Interfaces;
using System;
using System.Linq;
using System.Reflection;

namespace RecyclingStation.Models.Factories
{
    public class WasteFactory : IWasteFactory
    {
        private const string GarbageSuffix = "Garbage";

        public IWaste Create(string name, double weight, double volumePerKg, string type)
        {
            Type typeOfGarbage = Assembly.GetExecutingAssembly().GetTypes().FirstOrDefault(x => x.Name.Equals(type + GarbageSuffix, StringComparison.OrdinalIgnoreCase));

            object[] typeArgs = new object[] { name, weight, volumePerKg };

            IWaste waste = (IWaste)Activator.CreateInstance(typeOfGarbage, typeArgs);

            return waste;
        }
    }
}