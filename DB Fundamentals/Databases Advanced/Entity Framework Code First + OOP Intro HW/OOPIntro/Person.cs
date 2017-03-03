using System;

namespace OOPIntro
{
    public class Person
    {


        public Person()
        {
            this.Name = "No name";
            this.Age = 1;
        }
        public Person(int age) : this("No name", age) { }

        public Person(string name) : this(name, 1) { }

        public Person(string name, int age)
        {
            this.Name = name;
            this.Age = age;
        }

        private int age;

        public string Name { get; set; }

        public int Age
        {
            get
            {
                return this.age;
            }
            set
            {
                if (value < 0)
                {
                    throw new ArgumentOutOfRangeException("Age can't be a negative number!");
                }
                this.age = value;
            }
        }
    }
}
