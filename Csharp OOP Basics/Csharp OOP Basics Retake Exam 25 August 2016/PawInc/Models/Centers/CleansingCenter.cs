using PawInc.Models.Animals;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawInc.Models.Centers
{
    public class CleansingCenter : BaseCenter
    {
        public CleansingCenter(string name) : base(name)
        {
        }

        public List<BaseAnimal> Cleanse()
        {
            this.Animals.ForEach(a => a.CleansingStatus = true);
            var animals = new List<BaseAnimal>(this.Animals);
            this.Animals.Clear();
            return animals;
        }
    }
}