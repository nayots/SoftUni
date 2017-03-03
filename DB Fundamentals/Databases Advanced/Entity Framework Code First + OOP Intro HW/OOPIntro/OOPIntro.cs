using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPIntro
{
    class OOPIntro
    {
        static void Main(string[] args)
        {
            //1.	Define a class Person
            //DefinePersonClass();

            //2.	Create Person Constructors
            //CreatePeopleConstructors();

            //3.	Oldest Family Member
            //OldestFamilyMember();

            //4.	Students
            //DefineStudents();

            //5.	Planck Constant
            //PlanckConstraint();

            //6.	Math Utilities
            //MathUtilities();

        }

        private static void MathUtilities()
        {
            string input = Console.ReadLine();

            while (input != "End")
            {
                string[] inputArgs = input.Split();

                string command = inputArgs[0];

                double argOne = double.Parse(inputArgs[1]);
                double argTwo = double.Parse(inputArgs[2]);

                switch (command)
                {
                    case "Sum":
                        Console.WriteLine($"{MathUtil.Sum(argOne, argTwo):F2}");
                        break;
                    case "Subtract":
                        Console.WriteLine($"{MathUtil.Subtract(argOne, argTwo):F2}");
                        break;
                    case "Multiply":
                        Console.WriteLine($"{MathUtil.Multiply(argOne, argTwo):F2}");
                        break;
                    case "Divide":
                        Console.WriteLine($"{MathUtil.Divide(argOne, argTwo):F2}");
                        break;
                    case "Percentage":
                        Console.WriteLine($"{MathUtil.Percentage(argOne, argTwo):F2}");
                        break;
                    default:
                        Console.WriteLine($"Invalid command *{command}*");
                        break;
                }
                input = Console.ReadLine();
            }
        }

        private static void PlanckConstraint()
        {
            Console.WriteLine(Calculation.ReducedPlanck());
        }

        private static void DefineStudents()
        {
            Console.WriteLine("Enter a name or several each on a separate line:");
            string input = Console.ReadLine();

            while (input != "end")
            {
                Student student = new Student(input);
                input = Console.ReadLine();
            }


            Console.WriteLine(Student.count);
        }

        private static void OldestFamilyMember()
        {
            Console.Write("Number if people: ");
            int n = int.Parse(Console.ReadLine());
            Family family = new Family();
            for (int i = 0; i < n; i++)
            {
                Console.Write("Enter person name and age separated with space: ");
                string[] inputArgs = Console.ReadLine().Split();
                string name = inputArgs[0];
                int age = int.Parse(inputArgs[1]);

                family.AddMember(new Person(name, age));
            }

            Person oldest = family.GetOldestMember();

            Console.WriteLine($"{oldest.Name} {oldest.Age}");
        }

        private static void CreatePeopleConstructors()
        {
            Console.WriteLine("Enter person parameters or leave blank");
            string input = Console.ReadLine();

            List<Person> persons = new List<Person>();

            while (input != "end")
            {

                string[] inputArgs = input.Split(new char[] { ',', ' ' }, StringSplitOptions.RemoveEmptyEntries);

                if (inputArgs.Length == 0)
                {
                    persons.Add(new Person());
                }
                else if (inputArgs.Length == 1)
                {

                    int n;
                    bool isNumeric = int.TryParse(inputArgs[0], out n);

                    if (isNumeric)
                    {
                        persons.Add(new Person(n));
                    }
                    else
                    {
                        persons.Add(new Person(inputArgs[0]));
                    }

                }
                else
                {
                    string name = inputArgs[0];

                    int age = int.Parse(inputArgs[1]);

                    persons.Add(new Person { Name = name, Age = age });
                }

                Console.WriteLine("Enter *end* to stop adding and print out the results or add more info.");
                input = Console.ReadLine();
            }

            foreach (var p in persons)
            {
                Console.WriteLine($"{p.Name} {p.Age}");
            }
        }

        private static void DefinePersonClass()
        {
            Person personOne = new Person("Pesho", 20);
            Person personTwo = new Person();
            Person personThree = new Person("Stamat", 43);
        }
    }
}
