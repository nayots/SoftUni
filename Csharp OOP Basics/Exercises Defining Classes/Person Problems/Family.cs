using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

public class Family
{
    public Family()
    {
        this.FamilyMembers = new List<Person>();
    }

    public ICollection<Person> FamilyMembers { get; set; }

    public void AddMember(Person member)
    {
        this.FamilyMembers.Add(member);
    }

    public Person GetOldestMember()
    {
        return FamilyMembers.OrderByDescending(f => f.Age).First();
    }
}