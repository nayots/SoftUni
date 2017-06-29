using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

class StartUp
{
    private static void Main(string[] args)
    {
        //Problem1
        //Type personType = typeof(Person);
        //FieldInfo[] fields = personType.GetFields(BindingFlags.NonPublic | BindingFlags.Instance);
        //Console.WriteLine(fields.Length);

        //Problem2
        //Type personType = typeof(Person);
        //ConstructorInfo emptyCtor = personType.GetConstructor(new Type[] { });
        //ConstructorInfo ageCtor = personType.GetConstructor(new[] { typeof(int) });
        //ConstructorInfo nameAgeCtor = personType.GetConstructor(new[] { typeof(string), typeof(int) });
        //bool swapped = false;
        //if (nameAgeCtor == null)
        //{
        //    nameAgeCtor = personType.GetConstructor(new[] { typeof(int), typeof(string) });
        //    swapped = true;
        //}

        //string name = Console.ReadLine();
        //int age = int.Parse(Console.ReadLine());

        //Person basePerson = (Person)emptyCtor.Invoke(new object[] { });
        //Person personWithAge = (Person)ageCtor.Invoke(new object[] { age });
        //Person personWithAgeAndName = swapped ? (Person)nameAgeCtor.Invoke(new object[] { age, name }) : (Person)nameAgeCtor.Invoke(new object[] { name, age });

        //Console.WriteLine("{0} {1}", basePerson.Name, basePerson.Age);
        //Console.WriteLine("{0} {1}", personWithAge.Name, personWithAge.Age);
        //Console.WriteLine("{0} {1}", personWithAgeAndName.Name, personWithAgeAndName.Age);

        //Problem3
        //MethodInfo oldestMemberMethod = typeof(Family).GetMethod("GetOldestMember");
        //MethodInfo addMemberMethod = typeof(Family).GetMethod("AddMember");
        //if (oldestMemberMethod == null || addMemberMethod == null)
        //{
        //    throw new Exception();
        //}

        //Family family = new Family();
        //int n = int.Parse(Console.ReadLine());
        //for (int i = 0; i < n; i++)
        //{
        //    var tokens = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        //    var name = tokens[0];
        //    var age = int.Parse(tokens[1]);

        //    family.AddMember(new Person(name, age));
        //}

        //var oldest = family.GetOldestMember();
        //Console.WriteLine($"{oldest.Name} {oldest.Age}");

        //Problem4
        //List<Person> people = new List<Person>();

        //int n = int.Parse(Console.ReadLine());
        //for (int i = 0; i < n; i++)
        //{
        //    var tokens = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);
        //    var name = tokens[0];
        //    var age = int.Parse(tokens[1]);

        //    people.Add(new Person(name, age));
        //}

        //foreach (var person in people.Where(x => x.Age > 30).OrderBy(p => p.Name))
        //{
        //    Console.WriteLine($"{person.Name} - {person.Age}");
        //}

        //Problem5
        //var dm = new DateModifier();

        //dm.FindDifference(Console.ReadLine(), Console.ReadLine());

        //Console.WriteLine(dm.DateDifferenceDays);
    }
}