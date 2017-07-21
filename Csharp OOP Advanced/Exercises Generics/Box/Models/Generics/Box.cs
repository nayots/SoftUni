using System;
using System.Collections.Generic;
using System.Linq;

namespace Box.Models.Generics
{
    public class Box<T> where T : IComparable<T>
    {
        public Box(T value)
        {
            this.Value = value;
        }

        public T Value { get; set; }

        public int Compare(IList<Box<T>> collection, T element)
        {
            return collection.Where(i => i.Value.CompareTo(element) == 1).Count();
        }

        public override string ToString()
        {
            return $"{Value.GetType().FullName}: {Value}";
        }
    }
}