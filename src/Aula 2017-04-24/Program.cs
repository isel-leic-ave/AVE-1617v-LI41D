using System;
using System.Diagnostics;
using System.Reflection;
using NUnit.Framework;

namespace Aula_2017_04_24
{
    class Program
    {
        private  const int WARM_ITERS = 20;
        private const int  NUM_REPETITIONS = 5_000_000;
        static void Main(string[] args)
        {
            Student s = new Student(14, "Lindelof");


            //CopyStudentToPerson(s, new ReflectionCopier(), "Reflection");
            for (int i = 0; i < WARM_ITERS; i++)
            {
                CopyStudentToPerson(s, new CustomCopier(), "Custom");
                CopyStudentToPerson(s, new DynGeneratedCodeCopier(), "DynGenerated");
            }

            CopyStudentToPerson(s, new CustomCopier(), "Custom");
            CopyStudentToPerson(s, new DynGeneratedCodeCopier(), "DynGenerated");
            
        }


        private static void CopyStudentToPerson(Student s, ICopier copier, String message)
        {
            Stopwatch sw = new Stopwatch();
            sw.Start();
            Person p = null;
            for (int i = 0; i < NUM_REPETITIONS; ++i)
            {
                p = new Person();
                copier.Copy(s, p);

            }
            // Compare the last one just for sanity check
            Assert.AreEqual(s.Name, p.Name);
            Assert.AreEqual(s.Nr, p.Nr);
            sw.Stop();
            Console.WriteLine("{1} copy took {0}ms", sw.ElapsedMilliseconds, message);
        }
    }
    public interface ICopier
    {
        void Copy(Student s, Person p);
    }

    class CustomCopier : ICopier
    {
        public void Copy(Student s, Person p)
        {
            p.Name = s.Name;
            p.Nr = s.Nr;
        }
    }

    class ReflectionCopier : ICopier
    {
        FieldInfo[] fieldsStudent;
        FieldInfo[] fieldsPerson;

        public ReflectionCopier()
        {
            fieldsStudent = typeof(Student).GetFields(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
            fieldsPerson = typeof(Person).GetFields(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
        }

        public void Copy(Student s, Person p)
        {
            for (int j = 0; j < fieldsStudent.Length; j++)
            {
                FieldInfo fs = fieldsStudent[j];
                FieldInfo fp = fieldsPerson[j];

                fp.SetValue(p, fs.GetValue(s));
            }
        }
    }

    class DynGeneratedCodeCopier : ICopier
    {
        readonly ICopier dynCopier;

        public DynGeneratedCodeCopier()
        {
            //dynCopier = DynCopierBuilder.Create(typeof(Student), typeof(Person));
            dynCopier = DynCopierBuilder.Create<Student, Person>();
        }

        public void Copy(Student s, Person p)
        {
            dynCopier.Copy(s, p);
        }
    }

}
