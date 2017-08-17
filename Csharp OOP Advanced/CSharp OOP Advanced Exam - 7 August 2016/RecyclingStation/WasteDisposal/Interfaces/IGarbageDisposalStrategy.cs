namespace RecyclingStation.WasteDisposal.Interfaces
{
    /// <summary>
    /// Interface that should be implemented by Garbage Disposal Strategies.
    /// </summary>
    public interface IGarbageDisposalStrategy
    {
        /// <summary>
        /// Processes a passed in IWaste object by mapping out an appropriate strategy based on the object's Disposable Attribute. The method returns an IProcessingData object containing all information about the results of the operation.
        /// </summary>
        /// <param name="garbage">An IWaste object representing the garbage to be processed.</param>
        /// <returns>Returns an IProcessingData object containing all information about the results of processing the waste.</returns>
        IProcessingData ProcessGarbage(IWaste garbage);
    }
}