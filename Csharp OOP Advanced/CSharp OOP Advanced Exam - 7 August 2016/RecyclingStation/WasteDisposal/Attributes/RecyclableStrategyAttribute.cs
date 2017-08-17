using System;

namespace RecyclingStation.WasteDisposal.Attributes
{
    public class RecyclableStrategyAttribute : DisposableAttribute
    {
        public RecyclableStrategyAttribute(Type correspondintStrategyType) : base(correspondintStrategyType)
        {
        }
    }
}