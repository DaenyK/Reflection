using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Generator
{
    class Program
    {
        static void Main(string[] args)
        {

            Assembly genAssembly = Assembly.LoadFrom(@"C:\Users\КапашеваД\Documents\Visual Studio 2015\Projects\GeneratorName.dll");

            //foreach (Type item in genAssembly.GetTypes())
            //{
            //    Console.WriteLine("Name: {0}", item.Name);
            //    if(item.IsClass &&item.Name=="Generator")
            //    {
            //        //foreach (var p in item.GetMethods())
            //        //{
            //        //    Console.WriteLine("\tNameOfMethods: {0}", p.Name );
            //        //}

            //        MethodInfo mi = item.GetMethod("GenerateDefault");
            //        Console.WriteLine(mi.ReturnType);//возвращаемый тип

            //        foreach (ParameterInfo param in mi.GetParameters()) //принимаемые типы
            //        {
            //            Console.WriteLine(param.Name + " "+param.ParameterType);
            //        }
            //    }
            //}



            Type item = genAssembly.GetTypes()[2];
            Object Gen = Activator.CreateInstance(item);

            MethodInfo m = Gen.GetType().GetMethod("GenerateDefault");

            Object gender = null;
            var enymType = m.GetParameters()[0];
            if (m.GetParameters()[0].ParameterType.IsEnum)
            {
                gender = Enum.ToObject(m.GetParameters()[0].ParameterType, 0);
            }
            string result = m.Invoke(Gen, new object[] { gender }).ToString();
        }
    }
}
   