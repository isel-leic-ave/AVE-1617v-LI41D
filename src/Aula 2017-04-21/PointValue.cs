using System;

namespace Aula_2017_04_21
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

        // Default parameterless constructor cannot be defined
        //public PointValue() {
        //    X = -1;
        //    Y = -10;
        //}

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
