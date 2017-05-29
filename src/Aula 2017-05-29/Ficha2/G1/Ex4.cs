using System;

namespace Aula_2017_05_29.Ficha2.G1
{
    interface I { void m(); }

    class A : I
    {

        public virtual void m()
        {

            Console.WriteLine("A");
        }

    }


    class B : A
    {

        public override /*new*/ void m()
        {

            Console.WriteLine("B");
        }

    }

    class C : B
    {

        public /*new virtual*/ override  void m()
        {

            Console.WriteLine("C");
        }

    }


    class Ex4
    {

        public static void Main()
        {
            C c = new C();

            I i = c; A a = c; B b = c;

            i.m(); // B - A - C
            a.m(); // B - A - C
            b.m(); // B - B - C
            c.m(); // C - C - C


        }
    }

}


