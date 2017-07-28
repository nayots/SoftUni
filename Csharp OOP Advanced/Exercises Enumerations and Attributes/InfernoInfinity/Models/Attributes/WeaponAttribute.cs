using InfernoInfinity.Interfaces;
using System;
using System.Collections.Generic;

namespace InfernoInfinity.Models.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class WeaponAttribute : Attribute, IWeaponAttribute
    {
        public WeaponAttribute(string author, int revision, string description, params string[] reviewers)
        {
            this.Author = author;
            this.Revision = revision;
            this.Description = description;
            this.Reviewers = new List<string>();
            foreach (var reviewer in reviewers)
            {
                this.Reviewers.Add(reviewer);
            }
        }

        public string Author { get; private set; }
        public string Description { get; private set; }
        public IList<String> Reviewers { get; private set; }
        public int Revision { get; private set; }

        public string PrintInfo(string field)
        {
            switch (field)
            {
                case "Author":
                    return $"Author: {this.Author}";

                case "Revision":
                    return $"Revision: {this.Revision}";

                case "Description":
                    return $"Class description: {this.Description}";

                case "Reviewers":
                    return $"Reviewers: {string.Join(", ", this.Reviewers)}";

                default:
                    throw new ArgumentException($"Invalid attribute field: {field}");
            }
        }
    }
}