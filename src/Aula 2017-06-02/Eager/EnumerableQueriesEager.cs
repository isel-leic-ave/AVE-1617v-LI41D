using System;
using System.Collections.Generic;

namespace Aula_2017_06_02.Eager
{
    public static class EnumerableQueriesEager
    {
        public static void ForEach<T>(this IEnumerable<T> elements, Action<T> action)
        {
            foreach (T curr in elements)
            {
                action(curr);
            }
        }

        public static IEnumerable<T> Where<T>(this IEnumerable<T> elements, Predicate<T> pred)
        {
            IList<T> newSeq = new List<T>();
            foreach (T curr in elements)
            {
                if (pred(curr))
                {
                    newSeq.Add(curr);
                }
            }
            return newSeq;
        }

        public static IEnumerable<U> Select<T, U>(this IEnumerable<T> elements, Func<T, U> mapper)
        {
            IList<U> newSeq = new List<U>();
            foreach (T curr in elements)
            {
                    newSeq.Add(mapper(curr));
            }
            return newSeq;
        }

        public static IEnumerable<T> Take<T>(this IEnumerable<T> elements, int count)
        {
            IList<T> newSeq = new List<T>();
            foreach (T curr in elements)
            {
                if (count-- == 0)
                {
                    break;
                }
                newSeq.Add(curr);
            }
            return newSeq;
        }
    }
}