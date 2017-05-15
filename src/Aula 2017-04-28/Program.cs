using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula_2017_04_28
{
    class Program
    {
        static void Main(string[] args)
        {
            Foo f = new Foo();
            M1(f);
            
            Foo f1 = new FooDerived1();
            M1(f1);
        }

        public static void M1(Foo f)
        {
            f.SomeMethod();
        }
    }

    internal class Foo
    {
        public void SomeMethod()
        {
            Console.WriteLine("I'm in Foo");
        }
    }

    internal class FooDerived1 : Foo
    {
        public void SomeMethod()
        {
            Console.WriteLine("I'm on FooDerive1");
        }
    }
}
