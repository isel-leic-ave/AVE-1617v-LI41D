using System;

namespace Aula_2017_04_07
{
    public class Student
    {
        
        public int Number { get; set; }

        [Required(DefaultValue = "Undefined")]
        public string Name { get; set; }

        public override string ToString()
        {
            return Name;
        }
    }
}