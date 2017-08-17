using System;

namespace RecyclingStation.WasteDisposal.Attributes
{
    public class BurnableStrategyAttribute : DisposableAttribute
    {
        public BurnableStrategyAttribute(Type correspondintStrategyType) : base(correspondintStrategyType)
        {
        }
    }
}