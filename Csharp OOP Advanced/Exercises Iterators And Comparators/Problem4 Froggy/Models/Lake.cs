using System.Collections;
using System.Collections.Generic;

namespace Problem4_Froggy.Models
{
    public class Lake : IEnumerable<int>
    {
        public Lake(IEnumerable<int> stones)
        {
            this.Stones = new List<int>(stones);
        }

        public IList<int> Stones { get; set; }

        public IEnumerator<int> GetEnumerator()
        {
            for (int i = 0; i < this.Stones.Count; i += 2)
            {
                yield return this.Stones[i];
            }

            for (int i = this.Stones.Count - 1; i > 0; i--)
            {
                if (i % 2 == 0)
                {
                    continue;
                }
                yield return this.Stones[i];
            }
        }

        IEnumerator IEnumerable.GetEnumerator()
        {
            return this.GetEnumerator();
        }
    }
}