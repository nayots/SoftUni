using System.Collections.Generic;

namespace Problem6_Strategy_Pattern.Models.Comparators
{
    public class AgeComparer : IComparer<Person>
    {
        public int Compare(Person x, Person y)
        {
            int result = x.Age.CompareTo(y.Age);

            return result;
        }
    }
}