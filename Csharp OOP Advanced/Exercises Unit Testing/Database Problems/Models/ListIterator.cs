using System;
using System.Collections.Generic;

namespace Exercises_Models.Models
{
    public class ListIterator<T>
    {
        private int index;

        public ListIterator(IEnumerable<T> items)
        {
            this.Data = new List<T>();
            if (items is null)
            {
                throw new ArgumentNullException();
            }
            foreach (var item in items)
            {
                this.Data.Add(item);
            }
        }

        public IList<T> Data { get; private set; }

        public bool HasNext()
        {
            if ((this.index + 1) < this.Data.Count)
            {
                return true;
            }
            else
            {
                return false;
            }
        }

        public bool Move()
        {
            if (HasNext())
            {
                this.index++;
                return true;
            }
            else
            {
                return false;
            }
        }

        public string Print()
        {
            if (this.Data.Count > 0)
            {
                Console.WriteLine(this.Data[this.index]);
                return this.Data[this.index].ToString();
            }
            else
            {
                throw new InvalidOperationException("Invalid Operation!");
            }
        }
    }
}