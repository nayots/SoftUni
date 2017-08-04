using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;

namespace Exercises_Models.Models
{
    public class PeopleDB : IEnumerable<Person>
    {
        private const int Capacity = 16;

        private Person[] data;
        private int count;

        public PeopleDB(params Person[] items)
        {
            this.data = new Person[Capacity];
            foreach (var item in items)
            {
                this.Add(item);
            }
        }

        public int Count { get { return this.count; } }

        public void Add(Person person)
        {
            if (this.count == Capacity)
            {
                throw new InvalidOperationException("Database is full!");
            }

            if (PersonExists(person))
            {
                throw new InvalidOperationException("Person already exists!");
            }

            this.data[this.count] = person;
            this.count++;
        }

        private bool PersonExists(Person person)
        {
            if (this.Count == 0)
            {
                return false;
            }

            return this.data.Where(x => x != null).Any(p => p.Id == person.Id || p.Username == person.Username);
        }

        private bool PersonExists(string username)
        {
            if (this.Count == 0)
            {
                return false;
            }

            return this.data.Where(x => x != null).Any(p => p.Username == username);
        }

        private bool PersonExists(long id)
        {
            if (this.Count == 0)
            {
                return false;
            }

            return this.data.Where(x => x != null).Any(p => p.Id == id);
        }

        public Person Remove()
        {
            if (this.count == 0)
            {
                throw new InvalidOperationException("Database is empty!");
            }

            Person item = this.data[this.count - 1];
            this.data[this.count - 1] = default(Person);
            this.count--;
            return item;
        }

        public Person[] Fetch()
        {
            Person[] result = new Person[this.count];
            Array.Copy(this.data, result, this.count);

            return result;
        }

        public Person FindByUsername(string username)
        {
            if (string.IsNullOrEmpty(username))
            {
                throw new ArgumentNullException(string.Empty, "Username cannot be empty!");
            }
            if (!PersonExists(username))
            {
                throw new InvalidOperationException("Person does not exists in the database!");
            }

            return this.data.First(p => p.Username == username);
        }

        public Person FindById(long id)
        {
            if (id < 0)
            {
                throw new ArgumentOutOfRangeException(string.Empty, "Id cannot be a negative number!");
            }
            if (!PersonExists(id))
            {
                throw new InvalidOperationException("Person does not exists in the database!");
            }

            return this.data.First(p => p.Id == id);
        }

        public IEnumerator<Person> GetEnumerator()
        {
            for (int i = 0; i < this.count; i++)
            {
                yield return data[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}