using System;

namespace BashSoft.Attributes
{
    [AttributeUsage(AttributeTargets.Class)]
    public class AlliasAttribute : Attribute
    {
        private string name;

        public AlliasAttribute(string aliasName)
        {
            this.Name = aliasName;
        }

        public string Name { get => name; private set => name = value; }

        public override bool Equals(object obj)
        {
            return this.Name.Equals(obj);
        }
    }
}