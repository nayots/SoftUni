using PawInc.Models.Animals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawInc.Models.Centers
{
    public class CastrationCenter : BaseCenter
    {
        public CastrationCenter(string name) : base(name)
        {
        }

        public List<BaseAnimal> Castrate()
        {
            this.Animals.ForEach(a => a.CastrationStatus = true);
            var animals = new List<BaseAnimal>(this.Animals);
            this.Animals.Clear();
            return animals;
        }
    }
}