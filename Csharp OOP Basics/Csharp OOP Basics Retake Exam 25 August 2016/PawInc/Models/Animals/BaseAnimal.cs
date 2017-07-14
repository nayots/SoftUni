using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PawInc.Models.Animals
{
    public abstract class BaseAnimal
    {
        private string adoptionCenterName;
        private int age;
        private bool castrationStatus;
        private bool cleansingStatus;
        private string name;

        public BaseAnimal(string name, int age, string adoptionCenterName)
        {
            this.Name = name;
            this.Age = age;
            this.CleansingStatus = false;
            this.AdoptionCenterName = adoptionCenterName;
            this.CastrationStatus = false;
        }

        public string AdoptionCenterName
        {
            get { return this.adoptionCenterName; }
            protected set { this.adoptionCenterName = value; }
        }

        public int Age
        {
            get { return this.age; }
            set { this.age = value; }
        }

        public bool CastrationStatus
        {
            get { return this.castrationStatus; }
            set { this.castrationStatus = value; }
        }

        public bool CleansingStatus
        {
            get { return this.cleansingStatus; }
            set { this.cleansingStatus = value; }
        }

        public string Name
        {
            get { return this.name; }
            set { this.name = value; }
        }
    }
}