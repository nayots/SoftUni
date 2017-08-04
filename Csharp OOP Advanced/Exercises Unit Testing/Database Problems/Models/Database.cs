using System;
using System.Collections;
using System.Collections.Generic;

namespace Exercises_Models.Models
{
    public class Database<T> : IEnumerable<T>
    {
        private const int Capacity = 16;

        private T[] data;
        private int count;

        public Database(params T[] items)
        {
            this.data = new T[Capacity];
            foreach (var item in items)
            {
                this.Add(item);
            }
        }

        public int Count { get { return this.count; } }

        public void Add(T number)
        {
            if (this.count == Capacity)
            {
                throw new InvalidOperationException("Database is full!");
            }

            this.data[this.count] = number;
            this.count++;
        }

        public T Remove()
        {
            if (this.count == 0)
            {
                throw new InvalidOperationException("Database is empty!");
            }

            T item = this.data[this.count - 1];
            this.data[this.count - 1] = default(T);
            this.count--;
            return item;
        }

        public T[] Fetch()
        {
            T[] result = new T[this.count];
            Array.Copy(this.data, result, this.count);

            return result;
        }

        public IEnumerator<T> GetEnumerator()
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