using System;

namespace Aula_2017_05_19
{
    public class Stack<T>
    {
        private T []values;
        private int idx;

        public Stack(int limit)
        {
            Type t = typeof(T);
            Console.WriteLine(t.Name);

            values = new T[limit];
            idx = 0;
        }

        public void Push(T i)
        {
            if (idx == values.Length)
            {
                throw new InvalidOperationException("Push on an full stack");
            }
            values[idx++] = i;
        }

        public T Pop()
        {
            if (idx == 0)
            {
                throw new InvalidOperationException("Pop on an empty stack");
            }
            return values[--idx];
        }
    }
}