using Problem9_CollectionHierarchy.Interfaces;
using System.Collections.Generic;
using System.Linq;

namespace Problem9_CollectionHierarchy.Models
{
    public class MyList<T> : AddRemoveCollection<T>, IMyList<T>
    {
        public MyList()
        {
            this.Data = new List<T>();
        }

        public int Used { get { return this.Data.Count; } }

        public override T Remove()
        {
            var item = this.Data.First();
            this.Data.Remove(item);
            return item;
        }

        public override string ToString()
        {
            return string.Join(" ", new int[this.Data.Count]);
        }
    }
}