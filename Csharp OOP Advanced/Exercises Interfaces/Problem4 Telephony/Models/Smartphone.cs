using Problem4_Telephony.Interfaces;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem4_Telephony.Models
{
    public class Smartphone : ICallable, IBrowser
    {
        public Smartphone(ICollection<string> numbers, ICollection<string> urls)
        {
            this.Numbers = new List<string>(numbers);
            this.Urls = new List<string>(urls);
        }

        public ICollection<string> Urls { get; private set; }

        public ICollection<string> Numbers { get; private set; }

        public string Browse(string url)
        {
            if (url.Any(c => char.IsDigit(c)))
            {
                return "Invalid URL!";
            }
            else
            {
                return $"Browsing: {url}!";
            }
        }

        public string Call(string number)
        {
            if (!number.All(c => char.IsDigit(c)))
            {
                return "Invalid number!";
            }
            else
            {
                return $"Calling... {number}";
            }
        }

        public override string ToString()
        {
            var sb = new StringBuilder();

            foreach (var num in this.Numbers)
            {
                sb.AppendLine(Call(num));
            }

            foreach (var url in this.Urls)
            {
                sb.AppendLine(Browse(url));
            }

            return sb.ToString();
        }
    }
}