using Problem9_CollectionHierarchy.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Problem9_CollectionHierarchy.Models
{
    public class AddRemoveCollection<T> : IAddRemoveCollection<T>
    {
        public AddRemoveCollection()
        {
            this.Data = new List<T>();
        }

        protected IList<T> Data { get; set; }

        public void Add(T item)
        {
            this.Data.Insert(0, item);
        }

        public virtual T Remove()
        {
            var item = this.Data.Last();
            this.Data.Remove(item);
            return item;
        }

        public override string ToString()
        {
            return string.Join(" ", new int[this.Data.Count]);
        }
    }
}