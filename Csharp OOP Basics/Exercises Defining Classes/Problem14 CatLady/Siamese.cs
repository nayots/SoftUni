using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem14_CatLady
{
    public class Siamese : Cat
    {
        private int earSize;

        public Siamese(string name, int earSize)
        {
            this.Name = name;
            this.EarSize = earSize;
        }

        public int EarSize
        {
            get { return earSize; }
            set { earSize = value; }
        }

        public override string ToString()
        {
            return $"Siamese {this.Name} {this.EarSize}";
        }
    }
}