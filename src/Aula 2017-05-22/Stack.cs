using System;

namespace Aula_2017_05_22
{
    public class Stack<T> where T: IComparable<T> 
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

        public T Max()
        {
            T max = default(T);
            for (int i = 0; i < idx; i++)
            {
                if (values[i].CompareTo(max) > 0)
                    max = values[i];
            }

            return max;
        }


        //public delegate int Comparable(T t1, T t2);

        public T Max(Comparison<T> cmp)
        {
            T max = idx == 0 ? default(T) : values[0];
            for (int i = 1; i < idx; i++)
            {
                if (cmp(values[i], max) > 0)
                    max = values[i];
            }

            return max;
        }
    }
}