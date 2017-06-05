using System;
using System.Collections.Generic;
using Aula_2017_06_02.Eager;

namespace Aula_2017_06_02
{
    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<string> elements = new List<string> { "Sport", "Lisboa", "e", "Benfica", "-", "tetra", "rumo", "ao", "penta" };


            // Iterarint over the sequence using IEnumerable/Ienumerator directly
            Console.WriteLine("Iterating over the sequence using IEnumerable/Ienumerator directly");
            IEnumerator<string> en = elements.GetEnumerator();
            while (en.MoveNext())
            {
                string curr = en.Current;

                // DO something with each element

                Console.WriteLine(curr);

            }

            // Iterarint over the sequence using foreach statement
            Console.WriteLine("Iterating over the sequence using foreach statement");
            foreach (string curr in elements)
            {
                Console.WriteLine(curr);
            }


            Console.WriteLine("Filter-Select-ForEach with static methods, one in each instreuction");
            // Filter
            IEnumerable<string> filteredElements = EnumerableQueriesEager.Where(elements, s => s.Length > 3);
            // Map/Projection
            IEnumerable<int> mappedElements = EnumerableQueriesEager.Select(filteredElements, s => s.Length);
            // Iterate/go through each filtered and projected element
            EnumerableQueriesEager.ForEach(mappedElements, Console.WriteLine);

            Console.WriteLine("Filter-Select-ForEach with static methods, using a single and diffucult to read statement");

            EnumerableQueriesEager.ForEach(
                EnumerableQueriesEager.Select(
                    EnumerableQueriesEager.Where(elements, s => s.Length > 3), s => s.Length), Console.WriteLine);


            Console.WriteLine("Filter-Select-ForEach with static methods, using extension methods");

            elements
                .Where(s => s.Length > 3)
                .Select(s => s.Length)
                .ForEach(Console.WriteLine);

            



        }
    }
}
