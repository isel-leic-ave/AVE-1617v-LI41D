using System;

namespace Aula_2017_03_31
{
    public class TestingTypes
    {
        public static void Main(string[] args)
        {
            int x = 5;

            int y = x;

            x = 6;


            PointRef pr = new PointRef(2,3);
            PointRef pr1 = new PointRef(2, 3);

            PointRef pr2 = pr.Add(pr1);
            PointRef pr3 = pr2.Add(pr1);

            PointRef pr4 = pr3;

            Console.WriteLine(Object.ReferenceEquals(pr3, pr4));
            


            ChangeAndShow(pr);
            Console.WriteLine("Ouside ChangeAndShow: " + pr.X);

            PointValue pv = new PointValue(4,5);
            ChangeAndShow(pv);
            Console.WriteLine("Ouside ChangeAndShow: " + pv.X);


            PointValue pv1 = pv;
            Console.WriteLine(Object.ReferenceEquals(pv1, pv));

            Console.WriteLine(Object.ReferenceEquals(pv, pv));





        }

        static void ChangeAndShow(PointRef p)
        {
            p.X++;
            Console.WriteLine("Inside ChangeAndShow: " + p.X);

        }

        static void ChangeAndShow(PointValue pv)
        {
            pv.X++;
            Console.WriteLine("Inside ChangeAndShow: " + pv.X);
        }
    }
}