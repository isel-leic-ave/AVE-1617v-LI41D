using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula_2017_05_29.Ficha2.G2
{
    class Student
    {
        public String Name { get; set; }

        public int Number { get; set; }

    }

    class Ex1
    {

        string Process1(Student[] stds)
        {

            //StringBuilder sb = new StringBuilder();

            //foreach (Student s in stds) {

            //    sb.Append(s + "\n");

            //}

            //return sb.ToString();
            return Internal(stds, s => s.ToString());
        }

        string Process2(Student[] stds)
        {
            //StringBuilder sb = new StringBuilder();
            //foreach (Student s in stds) {

            //    sb.Append(s.Number + "\n");

            //}

            //return sb.ToString();

            return Internal(stds, s => s.Number.ToString());

        }

        string Internal(Student[] stds, Func<Student, String> studentToStr)
        {

            StringBuilder sb = new StringBuilder();

            foreach (Student s in stds)
            {

                sb.Append(studentToStr(s) + "\n");

            }

            return sb.ToString();

        }





    }
}
