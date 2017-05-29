using System;
using System.Text;

namespace Aula_2017_05_29
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

        public static Stack<S> Create<S>(int max) where S : IComparable<S>
        {
            return new Stack<S>(max);
        }

        public Stack<S> Create<S>(Func<T, S> conv) where S : IComparable<S>
        {
            Stack<S> s = new Stack<S>(this.values.Length);

            for (int i = 0; i < idx; i++)
            {
                s.Push(conv(values[i]));
            }

            return s;
        }

        public override string ToString()
        {
            StringBuilder sb = new StringBuilder("[");
            for (int i = 0; i < idx; i++)
            {
                sb.Append(values[i] + ",");
            }
            return sb.Append("]").ToString();
        }
    }
}