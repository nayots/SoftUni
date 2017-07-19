using Problem8_MilitaryElite.Enums;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem8_MilitaryElite
{
    public class Engineer : SpecialisedSoldier, IEngineer
    {
        public Engineer(string id, string firstName, string lastName, double salary, Corps corps) : base(id, firstName, lastName, salary, corps)
        {
            this.Repairs = new List<IRepair>();
        }

        public ICollection<IRepair> Repairs { get; protected set; }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendLine($"Corps: {this.Corps.ToString()}");
            sb.Append($"Repairs:");
            if (this.Repairs.Count > 0)
            {
                sb.AppendLine();
                var last = this.Repairs.Last();
                foreach (var rep in this.Repairs)
                {
                    if (rep == last)
                    {
                        sb.Append("  " + rep.ToString());
                    }
                    else
                    {
                        sb.AppendLine("  " + rep.ToString());
                    }
                }
            }

            return sb.ToString();
        }
    }
}