using Problem9_CollectionHierarchy.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Problem9_CollectionHierarchy.Models
{
    public class AddCollection<T> : IAddCollection<T>
    {
        public AddCollection()
        {
            this.Data = new List<T>();
        }

        private ICollection<T> Data { get; set; }

        public void Add(T item)
        {
            this.Data.Add(item);
        }

        public override string ToString()
        {
            return string.Join(" ", Enumerable.Range(0, this.Data.Count));
        }
    }
}