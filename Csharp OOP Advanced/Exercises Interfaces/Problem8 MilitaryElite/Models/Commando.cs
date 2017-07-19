using Problem8_MilitaryElite.Enums;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Problem8_MilitaryElite
{
    public class Commando : SpecialisedSoldier, ICommando
    {
        public Commando(string id, string firstName, string lastName, double salary, Corps corps) : base(id, firstName, lastName, salary, corps)
        {
            this.Missions = new List<IMission>();
        }

        public ICollection<IMission> Missions { get; protected set; }

        public override string ToString()
        {
            var sb = new StringBuilder();

            sb.AppendLine(base.ToString());
            sb.AppendLine($"Corps: {this.Corps.ToString()}");
            sb.Append($"Missions:");
            if (this.Missions.Count > 0)
            {
                sb.AppendLine();
                var last = this.Missions.Last();
                foreach (var miss in this.Missions)
                {
                    if (miss == last)
                    {
                        sb.Append("  " + miss.ToString());
                    }
                    else
                    {
                        sb.AppendLine("  " + miss.ToString());
                    }
                }
            }

            return sb.ToString();
        }
    }
}