using System;
using System.Collections;
using System.Collections.Generic;

namespace Exercises_Models.Models
{
    public class Bubble<T> : IEnumerable<T> where T : IComparable
    {
        private IList<T> data;

        public Bubble(params T[] items)
        {
            this.data = new List<T>();
            foreach (var item in items)
            {
                this.data.Add(item);
            }
            this.Sort();
        }

        public void Add(T item)
        {
            this.data.Add(item);
            this.Sort();
        }

        public IEnumerator<T> GetEnumerator()
        {
            return this.data.GetEnumerator();
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }

        private void Sort()
        {
            for (int i = 0; i < this.data.Count; i++)
            {
                for (int sort = 0; sort < this.data.Count - 1; sort++)
                {
                    if (this.data[sort].CompareTo(this.data[sort + 1]) == 1)
                    {
                        T temp = this.data[sort + 1];
                        this.data[sort + 1] = this.data[sort];
                        this.data[sort] = temp;
                    }
                }
            }
        }
    }
}