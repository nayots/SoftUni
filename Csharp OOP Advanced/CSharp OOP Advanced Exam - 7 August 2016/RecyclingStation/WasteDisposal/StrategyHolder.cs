namespace RecyclingStation.WasteDisposal
{
    using RecyclingStation.WasteDisposal.Interfaces;
    using System;
    using System.Collections.Generic;

    internal class StrategyHolder : IStrategyHolder
    {
        private readonly IDictionary<Type, IGarbageDisposalStrategy> strategies;

        public StrategyHolder(Dictionary<Type, IGarbageDisposalStrategy> strategies)
        {
            this.strategies = strategies;
        }

        public IReadOnlyDictionary<Type, IGarbageDisposalStrategy> GetDisposalStrategies
        {
            get { return (IReadOnlyDictionary<Type, IGarbageDisposalStrategy>)this.strategies; }
        }

        public bool AddStrategy(Type disposableAttribute, IGarbageDisposalStrategy strategy)
        {
            if (!this.strategies.ContainsKey(disposableAttribute))
            {
                this.strategies.Add(disposableAttribute, strategy);
                return true;
            }

            return false;
        }

        public bool RemoveStrategy(Type disposableAttribute)
        {
            if (this.strategies.ContainsKey(disposableAttribute))
            {
                this.strategies.Remove(disposableAttribute);
                return true;
            }

            return false;
        }
    }
}