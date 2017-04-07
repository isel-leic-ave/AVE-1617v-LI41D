using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Aula_2017_04_07
{
    public class Program
    {
        public static void Main(string[] args)
        {
            Student s = new Student();
            Console.WriteLine("Student before" + s);

            Type t = typeof(Student);
            PropertyInfo[] propertyInfos = t.GetProperties();
            foreach (PropertyInfo propertyInfo in propertyInfos)
            {
                Console.WriteLine("Property {0}", propertyInfo.Name);
                RequiredAttribute attr = (RequiredAttribute)propertyInfo.GetCustomAttribute(typeof(RequiredAttribute));
                if (attr != null)
                {
                    if (propertyInfo.GetMethod.Invoke(s, null) == null)
                    {
                        propertyInfo.SetMethod.Invoke(s, new object[] { attr.DefaultValue});
                    }
                    Console.WriteLine(attr.DefaultValue);
                }
            }
            Console.WriteLine("Student after" + s);
        }
    }
}
