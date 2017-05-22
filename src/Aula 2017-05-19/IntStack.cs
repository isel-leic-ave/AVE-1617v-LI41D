using System;

namespace Aula_2017_05_19
{
    public class IntStack
    {
        private int []values;
        private int idx;

        public IntStack(int limit)
        {
            values = new int[limit];
            idx = 0;
        }

        public void Push(int i)
        {
            if (idx == values.Length)
            {
                throw new InvalidOperationException("Push on an full stack");
            }
            values[idx++] = i;
        }

        public int Pop()
        {
            if (idx == 0)
            {
                throw new InvalidOperationException("Pop on an empty stack");
            }
            return values[--idx];
        }
    }
}