namespace Problem1_Logger.Models.Files.Contracts
{
    public interface ILogFile
    {
        void Write(string message);

        int Size { get; }
    }
}