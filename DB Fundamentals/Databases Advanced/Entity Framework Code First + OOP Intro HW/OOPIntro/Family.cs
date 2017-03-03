using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPIntro
{
    public class Family
    {
        public Family()
        {
            this.FamilyMembers = new HashSet<Person>();
        }
        public virtual HashSet<Person> FamilyMembers { get; set; }


        public void AddMember(Person member)
        {
            this.FamilyMembers.Add(member);
        }

        public Person GetOldestMember()
        {
            Person oldest = this.FamilyMembers.OrderByDescending(x => x.Age).ThenBy(z => z.Name).FirstOrDefault();

            return oldest;
        }
    }
}
