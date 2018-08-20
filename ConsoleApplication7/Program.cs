using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace ConsoleApplication7
{
    class Program
    {
        static void Main(string[] args)
        {

            //#region   
            //// Assembly a = Assembly.Load(@"C:\Users\КапашеваД\Documents\Visual Studio 2015\Projects\ConsoleApplication7\Lib\bin\Debug\Lib.dll");

            //Type myType = typeof(Person);


            ////  Person p = new Person("Tom", 30);
            //// Type myType2 = p.GetType();


            //// Type myType3 = Type.GetType("ConsoleApplication7.Person", false, true);

            //foreach (MemberInfo mi in myType.GetMembers())
            //{
            //    Console.WriteLine(mi.DeclaringType + " " + mi.MemberType + " " + mi.Name);
            //}
            //#endregion

            Assembly genAssembly = Assembly.LoadFrom(@"C:\Users\КапашеваД\Documents\Visual Studio 2015\Projects\ConsoleApplication7\Lib\bin\Debug\Lib.dll");

            Type[] ts = genAssembly.GetTypes();

            foreach (Type item in ts)
            {
                if (item.IsClass && item.Name == "Person")
                {
                    Console.WriteLine("Name: {0}, ({1})", item.Name, item.FullName);

                    Object exFromAsObj = Activator.CreateInstance(item); // создает экземпляр класса динамически

                    //foreach (MethodInfo m in exFromAsObj
                    //    .GetType()
                    //    .GetMethods(BindingFlags.Public | BindingFlags.Instance))
                    //{
                    //    Console.WriteLine("-> {0} ({1})",
                    //        m.Name, m.ReturnType);

                    //    foreach (ParameterInfo p in m.GetParameters())
                    //    {
                    //        Console.WriteLine(" --> {0} ({1})",
                    //            p.Name, p.ParameterType.BaseType);
                    //    }
                    //}

                    MethodInfo mtDisplay = exFromAsObj.GetType().GetMethod("Display");
                    //       object []param = new object[]
                    var result = mtDisplay.Invoke(exFromAsObj, null);


                    MethodInfo mtDisplayDob = exFromAsObj.GetType().GetMethod("DisplayDob");
                    object dob = DateTime.Now;
                    var result2 = mtDisplayDob.Invoke(exFromAsObj, new object[] { dob });


                }
            }




        }

    }


    //public class Person
    //{

    //    public Person(string name, int age)
    //    {
    //        Name = name;
    //        Age = age;
    //    }
    //    public string Name { get; set; }
    //    public int Age { get; set; }
    //    public void Display()
    //    { Console.WriteLine("Имя: {0}, возраст: {1}", Name, Age); }
    //}



}
