using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lib
{
    public class Person
    {
        public Person() { }
        public Person(string name, int age)
        {
            Name = name;
            Age = age;
        }
        public string Name { get; set; }
        public int Age { get; set; }
        public void Display()
        { Console.WriteLine(""); }

        public string DisplayDob(DateTime dob)
        {
            return string.Format("{0:dd.mm.yy}", dob.Date);
        }
    }
}

