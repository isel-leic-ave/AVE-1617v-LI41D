using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;

namespace Aula_2017_04_17
{
    class Ficha1
    {
        class Pair
        {
            public string Key { get; set; }
            public object Value { get; set; }
        }

        // utilização do método pedido

        static object CreateWithValues(Type t, Pair[] values)
        {
            Object ret = Activator.CreateInstance(t);
            for (int i = 0; i < values.Length; i++)
            {
                Pair p = values[i];
                t.GetProperty(p.Key).SetMethod.Invoke(ret, new[] { p.Value });
            }
            return ret;
        }

        public static void Run(string[] args)
        {
            Pair p1 = new Pair(); p1.Key = "P1"; p1.Value = 10;

            Pair p2 = new Pair(); p2.Key = "P2"; p2.Value = "P2";

            C c = (C)Ficha1.CreateWithValues(typeof(C), new Pair[] { p1, p2 });

        }
    }

    class C
    {
        public int P1 { get; set; }
        public string P2 { get; set; }
    }

}
