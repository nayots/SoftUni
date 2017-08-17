using System;

namespace Problem1_EventImplementation.Models
{
    public class NameChangeArgs : EventArgs
    {
        public NameChangeArgs(string name)
        {
            this.Name = name;
        }

        public string Name { get; protected set; }
    }
}