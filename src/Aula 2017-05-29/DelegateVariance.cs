using System;
using Aula_2017_05_29.Ficha2.G1;

namespace Aula_2017_05_29
{
    public class DelegateVariance
    {
        class A
        {
            
        }

        class B : A
        {
            
        }

        class C : B
        {
            
        }

        class D : B
        {
            
        }

        class X
        {
            
        }

        class Y : X
        {
            
        }

        class Z : X
        {
            
        }


        static void ArrarCoVariance(A []a)
        {
            a[0] = new C();

        }


        static X m1(A a)
        {
            return null; 
        }

        static X m2(D a)
        {
            return null;
        }

        static X m3(A a)
        {
            return null;
        }

        static Y m4(B a)
        {
            return new Y();
        }


        static void Process(Func<B, X> f, B b)
        {
            X x = f(b);

            Console.WriteLine(x);
        }

        static void Main(string[] args)
        {
            B[] bs = new D[10];
            ArrarCoVariance(bs);

            C c = new C();

            Process(m1, c);
            //Process(m2, c);  // Compiler Error. Argument types are not co-variant. 
            Process(m3, c);  // No error. Argument types are contra-variant.
            Process(m4, c);  // No error. return types are co-variant.

        }


        




    }
}