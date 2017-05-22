using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula_2017_05_15
{
    class Program
    {
        class A
        {

            public virtual void m1()
            {
                Console.WriteLine("A.m1");
            }

            public virtual void m2()
            {
                Console.WriteLine("A.m2");
            }

            public void m3()
            {
                Console.WriteLine("A.m3");
            }

            public virtual void m4()
            {
                Console.WriteLine("A.m4");
            }
        }

        class B :  A
        {
            public override void m1()
            {
                Console.WriteLine("B.m1");
            }

            public void m3()
            {
                Console.WriteLine("B.m3");
            }

            public new void m4()
            {
                Console.WriteLine("B.m3");
            }
        }

        static void Main(string[] args)
        {
            A a = new A();
            Process(a);

            B b = new B();
            Process(b);


            b.m3();
            Console.WriteLine(b.GetType().Name);
            A a1 = b;
            a1.m3();
            Console.WriteLine(a1.GetType().Name);

            b.m4();
            a1.m4();
        }

        private static void Process(A pa)
        {
            pa.m1();
            pa.m3();
        }
    }
}
