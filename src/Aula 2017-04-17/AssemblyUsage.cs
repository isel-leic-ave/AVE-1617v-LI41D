using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Reflection;

namespace Aula_2017_04_17
{
    class AssemblyUsage
    {
        static void ShowCurrentAssemblyName()
        {
            Type t = typeof(AssemblyUsage);

            Assembly a = t.Assembly;
            Console.WriteLine(a.FullName);
            AssemblyName aName = a.GetName();
            Console.WriteLine("Version" + aName.Version);
            

        }

        static void ShowAssemblyMetadata (Assembly a)
        {
            object []attrs = a.GetCustomAttributes(false);
            for(int i = 0; i < attrs.Length; ++i)
            {
                Console.WriteLine(attrs[i].ToString());
            }
        }

        static void ShowAssemblyTypes(Assembly a)
        {
            Console.WriteLine("-----------------  Types for Assembly {0} ----------", a.FullName);
            Type[] assemblyTypes = a.GetTypes();
            for (int i = 0; i < assemblyTypes.Length; ++i)
            {
                Type t = assemblyTypes[i];
                if(t.IsPublic)
                    Console.WriteLine(assemblyTypes[i]);
            }


        }

        public static void Main()
        {
            Assembly currentAssembly = typeof(AssemblyUsage).Assembly;
            ShowCurrentAssemblyName();
            ShowAssemblyMetadata(currentAssembly);

            Console.WriteLine("----------------------------------------");
            Assembly restSharpAssembly = Assembly.Load("RestSharp, Version=105.2.3.0, Culture=neutral, PublicKeyToken=null");
            ShowAssemblyMetadata(restSharpAssembly);

            ShowAssemblyTypes(restSharpAssembly);
        }
    }
}
