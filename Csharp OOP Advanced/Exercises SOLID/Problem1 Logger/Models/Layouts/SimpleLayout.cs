using Problem1_Logger.Models.Layouts.Contracts;

namespace Problem1_Logger.Models.Layouts
{
    public class SimpleLayout : ILayout
    {
        public SimpleLayout()
        {
            this.Format = "{0} - {1} - {2}";
        }

        public string Format { get; private set; }
    }
}