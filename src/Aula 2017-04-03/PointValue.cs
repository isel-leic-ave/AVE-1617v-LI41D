using System;

namespace Aula_2017_04_03
{
    /// <summary>
    /// 
    /// </summary>
    public struct PointValue
    {
        /// <summary>
        /// 
        /// </summary>
        public int X { get; set; }
        public int Y { get; set; }

        /// <summary>
        /// 
        /// </summary>
        /// <param name="x"></param>
        /// <param name="y"></param>
        public PointValue(int x, int y)
        {
            this.X = x;
            this.Y = y;
        }

        public PointValue Add(PointValue p)
        {
            return new PointValue(this.X + p.X, this.Y + p.Y);
        }
    }
}
