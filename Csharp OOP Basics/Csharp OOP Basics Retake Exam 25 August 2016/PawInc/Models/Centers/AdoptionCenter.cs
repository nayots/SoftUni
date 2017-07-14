using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawInc.Models.Centers
{
    public class AdoptionCenter : BaseCenter
    {
        public AdoptionCenter(string name) : base(name)
        {
        }

        public void Adopt()
        {
            this.Animals.RemoveAll(a => a.CleansingStatus == true);
        }
    }
}