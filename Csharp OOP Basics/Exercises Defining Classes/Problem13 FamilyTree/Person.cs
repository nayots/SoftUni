using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem13_FamilyTree
{
    public class Person
    {
        public Person(string firstName, string lastName)
        {
            this.FirstName = firstName;
            this.LastName = lastName;
            this.Parents = new List<Person>();
            this.Children = new List<Person>();
        }

        public Person(string date)
        {
            this.Date = date;
            this.Parents = new List<Person>();
            this.Children = new List<Person>();
        }

        public Person(string firstName, string lastName, string date)
            : this(firstName, lastName)
        {
            this.Date = date;
        }

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Date { get; set; }
        public List<Person> Parents { get; set; }
        public List<Person> Children { get; set; }

        public override string ToString()
        {
            return $"{this.FirstName} {this.LastName} {this.Date}";
        }
    }
}