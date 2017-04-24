using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula_2017_04_21
{
    class Program
    {
        static void Main(string[] args)
        {
            PointValue pv = new PointValue();
            PointValue pv1;
            Object o = pv;

            PointValue pv3 = (PointValue)o;

            

            //PointValue pv2 = new PointValue(2,3);

            //PointRef pr = new PointRef();

            //ShowObject(pr);
            //ShowObject(pv);



        }

        private static void ShowObject(Object o)
        {
            Console.WriteLine(o.GetType().FullName);
        }
    }
}
