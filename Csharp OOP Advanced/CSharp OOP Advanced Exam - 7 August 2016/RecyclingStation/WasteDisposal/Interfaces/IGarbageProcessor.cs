namespace RecyclingStation.WasteDisposal.Interfaces
{
    /// <summary>
    /// Interface that specifies the behaviour Garbage Processors have to implement.
    /// </summary>
    public interface IGarbageProcessor
    {
        /// <summary>
        /// An IStrategyHolder object holding the currently contained strategies.
        /// </summary>
        IStrategyHolder StrategyHolder { get; }

        /// <summary>
        /// Identifies and executes a disposal strategy from the strategies contained in the StrategyHolder based on the passed in garbage's Disposable Attribute.
        /// </summary>
        /// <param name="garbage">An object of type IWaste representing garbage that should be processed.</param>
        ///  <exception cref="ArgumentException">In case passed in garbage does not contain an attribute derived from the Disposable Attribute class, throws an Argument Exception.</exception>
        /// <returns>Returns an object of type IProcessingData containing all information about the result of processing the passed in IWaste object.</returns>
        IProcessingData ProcessWaste(IWaste garbage);
    }
}