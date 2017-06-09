using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula_2017_06_09
{
    interface IA
    {
        void m1();
        void m2();
    }


    interface IB
    {
        int m1();
        void m3();
    }

    class C1 : IA, IB
    {
        public void m1()
        {

        }

        int IB.m1()
        {
            return 0;
        }


        void IA.m2()
        {
            
        }

        public void m3()
        {

        }

    }

    class Program
    {

        static IA Foo()
        {
            return null;
        }


        static void Main(string[] args)
        {

            // Interface explicit implementation
            //C1 c = new C1();
            //IA ia = c;
            //ia.m1();

            //Foo().m1();

            //((IA)c).m1();



            // NUllable types

            Nullable<int> i = null;

            Console.WriteLine(i.HasValue);

            Console.WriteLine(i.Value);




        }
    }
}
