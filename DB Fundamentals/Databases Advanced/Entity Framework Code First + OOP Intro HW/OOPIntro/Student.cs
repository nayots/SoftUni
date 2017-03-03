using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace OOPIntro
{
    public class Student
    {
        public static int count { get; protected set; } = 0;
        public string Name { get; set; }

        public Student(string name)
        {
            this.Name = name;
            count++;
        }
    }
}
