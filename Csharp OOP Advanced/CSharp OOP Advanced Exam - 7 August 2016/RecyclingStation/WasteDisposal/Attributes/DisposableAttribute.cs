namespace RecyclingStation.WasteDisposal.Attributes
{
    using System;

    /// <summary>
    /// An attribute class, that represents the base of all Disposable Attribute classes.
    /// </summary>

    [AttributeUsage(AttributeTargets.Class)]
    public class DisposableAttribute : Attribute
    {
        private Type correspondintStrategyType;

        public DisposableAttribute(Type correspondintStrategyType)
        {
            CorrespondintStrategyType = correspondintStrategyType;
        }

        public Type CorrespondintStrategyType { get => correspondintStrategyType; private set => correspondintStrategyType = value; }
    }
}