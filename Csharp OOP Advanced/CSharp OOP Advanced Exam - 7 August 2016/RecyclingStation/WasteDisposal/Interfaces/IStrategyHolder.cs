namespace RecyclingStation.WasteDisposal.Interfaces
{
    using System;
    using System.Collections.Generic;

    /// <summary>
    /// Interface that specifies the behaviour Strategy Holders have to implement.
    /// </summary>
    public interface IStrategyHolder
    {
        /// <summary>
        /// Returns a readonly version of the collection of type Type-IGarbageDisposalStrategy, containing the currently mapped strategies.
        /// </summary>
        IReadOnlyDictionary<Type, IGarbageDisposalStrategy> GetDisposalStrategies { get; }

        /// <summary>
        /// Maps a strategy to an attribute type and adds it to the currently contained strategies, can contain only unique attribute types. Throws an exception in case that disposableAttribute is a type that is not derived from the Disposable Attribute class.
        /// </summary>
        /// <param name="disposableAttribute">A type derived from the Disposable Attribute class.</param>
        /// <param name="strategy">An object of IGarbageDisposalStrategy type that will be mapped to disposableAttribute.</param>
        /// <exception cref="ArgumentException">In case the disposableAttribute is not a type derived from the Disposable Attribute class throws an Argument Exception.</exception>
        /// <returns>Returns false if the adding failed (for example if disposableAttribute already exists in the strategies) or true if the adding was successfull. (</returns>
        bool AddStrategy(Type disposableAttribute, IGarbageDisposalStrategy strategy);

        /// <summary>
        /// Removes an attribute type and its corresponding strategy from the currently contained strategies. Throws an exception in case that the passed in disposableAttribute is a type not derived from the Disposable Attribute class.
        /// </summary>
        /// <param name="disposableAttribute">A type derived from the Disposable Attribute class.</param>
        ///  <exception cref="ArgumentException">In case the disposableAttribute is not a type derived from the Disposable Attribute class throws an Argument Exception.</exception>
        /// <returns>Return false if the removal failed (ex. the passed in disposableAttribute is not contained in the current strategies) or returns true if the removing was sucessfull.</returns>
        bool RemoveStrategy(Type disposableAttribute);
    }
}