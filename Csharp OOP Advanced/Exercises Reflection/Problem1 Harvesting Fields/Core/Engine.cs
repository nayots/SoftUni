using System;
using System.Linq;
using System.Reflection;

namespace Problem1_Harvesting_Fields.Core
{
    public class Engine
    {
        public void Run()
        {
            string command = string.Empty;
            FieldInfo[] allFields = typeof(HarvestingFields).GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);

            while ((command = Console.ReadLine()) != "HARVEST")
            {
                ExecuteCommand(command, allFields);
            }
        }

        private void ExecuteCommand(string command, FieldInfo[] allFields)
        {
            FieldInfo[] gatheredFields;
            switch (command)
            {
                case "public":
                    gatheredFields = allFields.Where(f => f.IsPublic).ToArray();
                    break;

                case "private":
                    gatheredFields = allFields.Where(f => f.IsPrivate).ToArray();
                    break;

                case "protected":
                    gatheredFields = allFields.Where(f => f.IsFamily).ToArray();
                    break;

                case "all":
                    gatheredFields = allFields;
                    break;

                default:
                    throw new InvalidOperationException("Unknown command!");
            }

            string[] result = gatheredFields.Select(f => $"{f.Attributes.ToString().ToLower()} {f.FieldType.Name} {f.Name}").ToArray();
            Console.WriteLine(string.Join(Environment.NewLine, result).Replace("family", "protected"));
        }
    }
}