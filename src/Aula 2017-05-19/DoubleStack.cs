using System;

namespace Aula_2017_05_19
{
    public class DoubleStack
    {
        private double []values;
        private int idx;

        public DoubleStack(int limit)
        {
            values = new double[limit];
            idx = 0;
        }

        public void Push(double i)
        {
            if (idx == values.Length)
            {
                throw new InvalidOperationException("Push on an full stack");
            }
            values[idx++] = i;
        }

        public double Pop()
        {
            if (idx == 0)
            {
                throw new InvalidOperationException("Pop on an empty stack");
            }
            return values[--idx];
        }
    }
}