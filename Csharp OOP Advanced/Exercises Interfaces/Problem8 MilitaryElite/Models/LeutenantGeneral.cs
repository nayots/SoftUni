using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem8_MilitaryElite
{
    public class LeutenantGeneral : Private, ILeutenantGeneral
    {
        public LeutenantGeneral(string id, string firstName, string lastName, double salary) : base(id, firstName, lastName, salary)
        {
            this.Privates = new List<IPrivate>();
        }

        public ICollection<IPrivate> Privates { get; protected set; }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.Append($"Privates:");
            if (this.Privates.Count > 0)
            {
                sb.AppendLine();
                var last = this.Privates.Last();
                foreach (var priv in this.Privates)
                {
                    if (priv == last)
                    {
                        sb.Append("  " + priv.ToString());
                    }
                    else
                    {
                        sb.AppendLine("  " + priv.ToString());
                    }
                }
            }

            return sb.ToString();
        }
    }
}