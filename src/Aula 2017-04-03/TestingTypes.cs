using System;

namespace Aula_2017_04_03
{
    public class TestingTypes
    {
        public static void Main(string[] args)
        {
            PointRef pr = null; //new PointRef(2,3);
            PointRef pr1 = new PointRef(5, 3);
            PointRef pr2 = pr.Add(pr1);

            PointValue pv = new PointValue(4,5);
            PointValue pv1 = new PointValue(5, 3);
            PointValue pv2 = pv.Add(pv1);
        }


    }
}