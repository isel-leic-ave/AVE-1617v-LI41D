using System;

namespace Aula_2017_05_19
{
    public class ObjectStack
    {
        private Object []values;
        private int idx;

        public ObjectStack(int limit)
        {
            values = new Object[limit];
            idx = 0;
        }

        public void Push(Object i)
        {
            if (idx == values.Length)
            {
                throw new InvalidOperationException("Push on an full stack");
            }
            values[idx++] = i;
        }

        public Object Pop()
        {
            if (idx == 0)
            {
                throw new InvalidOperationException("Pop on an empty stack");
            }
            return values[--idx];
        }
    }
}