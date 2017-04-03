using System;

namespace Aula_2017_03_31
{
    public class PointRef    {
        public int X { get; set; }
        public int Y { get; set; }

        public PointRef(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public PointRef Add(PointRef p)
        {
            return new PointRef(this.X + p.X, this.Y + p.Y);
        }
    }
}
