namespace RecyclingStation.WasteDisposal.Interfaces
{
    /// <summary>
    /// Interface that Garbage objects should implement.
    /// </summary>
    public interface IWaste
    {
        /// <summary>
        /// The name of the waste product.
        /// </summary>
        string Name { get; }

        /// <summary>
        /// Defines the volume in cubic centimeters (cm3) that 1 kilogram of Garbage takes.
        /// </summary>
        double VolumePerKg { get; }

        /// <summary>
        /// Holds the weight of the garbage in kilograms.
        /// </summary>
        double Weight { get; }
    }
}