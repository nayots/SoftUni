namespace _01.Stream_Progress
{
    public class StreamProgressInfo
    {
        private IStreamable file;

        // If we want to stream a music file, we can't
        public StreamProgressInfo(IStreamable file)
        {
            this.file = file;
        }

        public int CalculateCurrentPercent()
        {
            return (this.file.BytesSent * 100) / this.file.Length;
        }
    }
}