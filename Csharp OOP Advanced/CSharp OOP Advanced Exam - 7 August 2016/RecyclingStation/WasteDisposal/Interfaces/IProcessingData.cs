namespace RecyclingStation.WasteDisposal.Interfaces
{
    /// <summary>
    /// Interface that should be implemented by Processing Data objects.
    /// </summary>
    public interface IProcessingData
    {
        /// <summary>
        /// The resulting profit/loss in energy from processing the garbage, if the number is negative it means the process used more energy than it produced.
        /// </summary>
        double EnergyBalance { get; }

        /// <summary>
        /// The resulting profit/loss in capital from processing the garbage, if the number is negative it means the process costed more, than the ammount of profits it provided.
        /// </summary>
        double CapitalBalance { get; }
    }
}