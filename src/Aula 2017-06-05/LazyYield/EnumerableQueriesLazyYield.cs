using System;
using System.Collections.Generic;

namespace Aula_2017_06_05.LazyYield
{
    public static class EnumerableQueriesLazyYield
    {
        public static IEnumerable<string> GetBestStrings(IEnumerable<string> strs )
        {
            //IEnumerable<string> strs = new List<string> { "Sport", "Lisboa", "e", "Benfica", "-", "tetra", "rumo", "ao", "penta" };
            foreach (var str in strs)
            {
                yield return str;
            }
        }


  
            public static void ForEach<T>(this IEnumerable<T> elements, Action<T> action)
            {
                foreach (T curr in elements)
                {
                    action(curr);
                }
            }
    
            public static IEnumerable<T> Where<T>(this IEnumerable<T> elements, Predicate<T> pred)
            {
                foreach (T curr in elements)
                {
                    Console.WriteLine("where: processing {0}", curr);
                    if (pred(curr))
                        yield return curr;
                }
            }
    
            public static IEnumerable<U> Select<T, U>(this IEnumerable<T> elements, Func<T, U> mapper)
            {
                foreach (T curr in elements)
                {
                Console.WriteLine("select: processing {0}", curr);

                yield return mapper(curr);
                }
            }
    
           
    
            public static IEnumerable<T> Take<T>(this IEnumerable<T> elements, int count)
            {

                foreach (T curr in elements)
                {
                    Console.WriteLine("take: processing {0}", curr);

                    if (count-- == 0)
                    {
                        yield break;
                    }
                    yield return curr;
                }
            }

        public static IEnumerable<T> TakeWhile<T>(this IEnumerable<T> elements, Predicate<T> pred)
        {

            foreach (T curr in elements)
            {
                Console.WriteLine("takeWhile: processing {0}", curr);

                if (!pred(curr))
                {
                    yield break;
                }
                yield return curr;
            }
        }


    }
    
}