using System;

namespace Aula2017_03_20.tpc1
{
    public class Student
    {
        public Student(int number) : this(number, String.Empty)
        {
            
        }

        public Student(int number, string name)
        {
            Number = number;
            Name = name;
        }


        public int Number { get; set; }
        public String Name { get; set; }
    }
}