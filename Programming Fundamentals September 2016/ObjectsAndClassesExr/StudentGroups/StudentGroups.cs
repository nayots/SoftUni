using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;
using System.Globalization;
//10. Student Groups
namespace StudentGroups
{
    class StudentGroups
    {
        static void Main(string[] args)
        {
            List<Town> towns = GetTownData();
            List<Group> groups = GetGroups(towns);
            PrintResults(groups);
        }

        private static void PrintResults(List<Group> groups)
        {

            int townsCount = groups.Select(x => x.Town).Distinct().Count();

            Console.WriteLine($"Created {groups.Count} groups in {townsCount} towns:");

            foreach (var group in groups.OrderBy(x => x.Town.Name))
            {
                Console.Write($"{group.Town.Name} => ");

                Console.WriteLine($"{string.Join(", ", group.Students.Select(x => x.Email))}");
            }

        }

        private static List<Group> GetGroups(List<Town> towns)
        {
            List<Group> groups = new List<Group>();

            foreach (var town in towns.OrderBy(x => x.Name))
            {

                IEnumerable<Student> studs = town.Students.OrderBy(x => x.RegistrationDate).ThenBy(z => z.Name).ThenBy(y => y.Email);

                while (studs.Any())
                {
                    Group group = new Group();
                    group.Town = town;
                    group.Students = studs.Take(group.Town.SeatsCount).ToList();
                    studs = studs.Skip(group.Town.SeatsCount);
                    groups.Add(group);
                }
            }
            return groups;
        }

        private static List<Town> GetTownData()
        {
            List<Town> towns = new List<Town>();
            string inputLine = Console.ReadLine();

            while (inputLine != "End")
            {
                if (inputLine.Contains("=>"))
                {
                    Town town = new Town();
                    List<string> input = Regex.Split(inputLine, @"\s=>\s").ToList();
                    string townName = input[0];
                    int seats = int.Parse(Regex.Match(input[1], @"\d+").Value);

                    town.Name = townName;
                    town.SeatsCount = seats;
                    town.Students = new List<Student>();

                    towns.Add(town);
                }
                else
                {
                    List<string> input = inputLine.Split(new char[] { '|' }, StringSplitOptions.RemoveEmptyEntries).Select(x => x.Trim()).ToList();
                    Student student = new Student();
                    string studName = input[0];
                    string eMail = input[1];
                    DateTime regDate = DateTime.ParseExact(input[2], "d-MMM-yyyy", CultureInfo.InvariantCulture);

                    student.Name = studName;
                    student.Email = eMail;
                    student.RegistrationDate = regDate;

                    towns.LastOrDefault().Students.Add(student);
                }
                inputLine = Console.ReadLine();
            }
            return towns;
        }
    }

    class Student
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public DateTime RegistrationDate { get; set; }
    }

    class Town
    {
        public string Name { get; set; }
        public int SeatsCount { get; set; }
        public List<Student> Students { get; set; }
    }

    class Group
    {
        public Town Town { get; set; }
        public List<Student> Students { get; set; }
    }
}
