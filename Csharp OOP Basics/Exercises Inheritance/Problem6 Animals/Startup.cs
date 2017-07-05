using Problem6_Animals.Cats;
using Problem6_Animals.Dogs;
using Problem6_Animals.Frogs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Problem6_Animals
{
    class Startup
    {
        private static void Main(string[] args)
        {
            List<Animal> animals = new List<Animal>();

            var animal = Console.ReadLine();

            while (animal != "Beast!")
            {
                try
                {
                    var details = Console.ReadLine().Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries);

                    var name = details[0];
                    var gender = details[2];
                    int age;
                    if (!int.TryParse(details[1], out age))
                    {
                        ThrowEx();
                    }

                    switch (animal)
                    {
                        case "Cat":
                            animals.Add(new Cat(name, age, gender));
                            break;

                        case "Tomcat":
                            animals.Add(new Tomcat(name, age));
                            break;

                        case "Kitten":
                            animals.Add(new Kitten(name, age));
                            break;

                        case "Frog":
                            animals.Add(new Frog(name, age, gender));
                            break;

                        case "Dog":
                            animals.Add(new Dog(name, age, gender));
                            break;

                        default:
                            ThrowEx();
                            break;
                    }
                }
                catch (ArgumentException ae)
                {
                    Console.WriteLine(ae.Message);
                }
                animal = Console.ReadLine();
            }

            foreach (var a in animals)
            {
                Console.WriteLine(a.ToString());
            }
        }

        public static ArgumentException ThrowEx()
        {
            throw new ArgumentException("Invalid input!");
        }
    }
}