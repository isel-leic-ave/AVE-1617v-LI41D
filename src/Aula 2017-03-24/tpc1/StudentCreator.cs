using System;
using System.Reflection;

namespace Aula2017_03_24.tpc1
{
    public class StudentCreator
    {
        public static Student Create(int number)
        {
           Type t = typeof(Student);
           ConstructorInfo constructor =  t.GetConstructor(new[] {typeof(int)});
           return (Student)constructor.Invoke(new object[] {number});
        }

        public static Student Create(int number, string name)
        {
            Type t = typeof(Student);
            ConstructorInfo constructor = t.GetConstructor(new[] { typeof(int), typeof(String) });
            return (Student)constructor.Invoke(new object[] { number, name });
        }
    }
}