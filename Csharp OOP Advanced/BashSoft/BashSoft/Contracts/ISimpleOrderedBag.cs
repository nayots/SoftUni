using System;
using System.Collections.Generic;

namespace BashSoft.Contracts
{
    public interface ISimpleOrderedBag<T> : IEnumerable<T> where T : IComparable<T>
    {
        int Capacity { get; }
        int Size { get; }

        void Add(T element);

        void AddAll(ICollection<T> collection);

        string JoinWith(string joiner);

        bool Remove(T element);
    }
}