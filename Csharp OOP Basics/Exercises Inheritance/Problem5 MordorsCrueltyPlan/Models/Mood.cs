using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem5_MordorsCrueltyPlan.Models
{
    public class Mood
    {
        private string description;

        public Mood(string desc)
        {
            this.Description = desc;
        }

        public string Description
        {
            get { return this.description; }
            set { this.description = value; }
        }
    }
}