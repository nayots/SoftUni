using System;
using System.Collections.Generic;

namespace CustomAttribute.Attributes
{
    [AttributeUsage(AttributeTargets.Class, AllowMultiple = true)]
    public class InfoAttribute : Attribute
    {
        public InfoAttribute(string author, int revision, string description, params string[] reviewers)
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
        public int Revision { get; private set; }
        public string Description { get; private set; }
        public IList<String> Reviewers { get; private set; }

        public void PrintInfo(string field)
        {
            switch (field)
            {
                case "Author":
                    Console.WriteLine($"Author: {this.Author}");
                    break;

                case "Revision":
                    Console.WriteLine($"Revision: {this.Revision}");
                    break;

                case "Description":
                    Console.WriteLine($"Class description: {this.Description}");
                    break;

                case "Reviewers":
                    Console.WriteLine($"Reviewers: {string.Join(", ", this.Reviewers)}");
                    break;

                default:
                    break;
            }
        }
    }
}