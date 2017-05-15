using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula_2017_05_05
{
    class Program
    {
        static void Main(string[] args)
        {
            Base f = new Base();
            M1(f);

            Base f1 = new Derived1();
            M1(f1);
        }

        private static void M1(Base b)
        {
            b.Method1();
            b.Method2();
        }
    }

    internal class Derived1 : Base
    {
    }

    internal class Base
    {
        public void Method1()
        {
            Console.WriteLine("Method 1 in Base");
        }

        public void Method2()
        {
            Console.WriteLine("Method 2 in Base");
        }
    }
}
