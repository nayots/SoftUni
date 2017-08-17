namespace RecyclingStation.WasteDisposal
{
    using RecyclingStation.WasteDisposal.Attributes;
    using RecyclingStation.WasteDisposal.Interfaces;
    using System;
    using System.Linq;

    public class GarbageProcessor : IGarbageProcessor
    {
        public GarbageProcessor(IStrategyHolder strategyHolder)
        {
            this.StrategyHolder = strategyHolder;
        }

        public IStrategyHolder StrategyHolder { get; private set; }

        public IProcessingData ProcessWaste(IWaste garbage)
        {
            Type type = garbage.GetType();
            DisposableAttribute disposalAttribute = (DisposableAttribute)type.GetCustomAttributes(typeof(DisposableAttribute), true).FirstOrDefault();

            if (disposalAttribute == null)
            {
                throw new ArgumentException(
                    "The passed in garbage does not implement a supported Disposable Strategy Attribute.");
            }

            Type typeOfAttribute = disposalAttribute.GetType();

            if (!this.StrategyHolder.GetDisposalStrategies.ContainsKey(typeOfAttribute))
            {
                Type typeOfCorrespondingStrategy = disposalAttribute.CorrespondintStrategyType;

                IGarbageDisposalStrategy activatedStrategy = (IGarbageDisposalStrategy)Activator.CreateInstance(typeOfCorrespondingStrategy);

                this.StrategyHolder.AddStrategy(typeOfAttribute, activatedStrategy);
            }

            IGarbageDisposalStrategy currentStrategy = this.StrategyHolder.GetDisposalStrategies[typeOfAttribute];

            return currentStrategy.ProcessGarbage(garbage);
        }
    }
}