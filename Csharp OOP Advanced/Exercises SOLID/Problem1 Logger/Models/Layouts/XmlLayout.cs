using Problem1_Logger.Models.Layouts.Contracts;
using System;

namespace Problem1_Logger.Models.Layouts
{
    public class XmlLayout : ILayout
    {
        public XmlLayout()
        {
            this.Format =
                $"<log>{Environment.NewLine}" +
                "   <date>{0}</date>" + Environment.NewLine +
                "   <level>{1}</level>" + Environment.NewLine +
                "   <message>{2}</message>" + Environment.NewLine +
                "</log>";
        }

        public string Format { get; private set; }
    }
}