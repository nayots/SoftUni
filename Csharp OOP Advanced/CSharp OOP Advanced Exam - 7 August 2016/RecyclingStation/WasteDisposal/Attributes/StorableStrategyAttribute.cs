using System;

namespace RecyclingStation.WasteDisposal.Attributes
{
    public class StorableStrategyAttribute : DisposableAttribute
    {
        public StorableStrategyAttribute(Type correspondintStrategyType) : base(correspondintStrategyType)
        {
        }
    }
}