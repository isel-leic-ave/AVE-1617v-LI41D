using System;
using System.Collections.Generic;
using System.Text;
using Aula_2017_06_05.LazyYield;

namespace Aula_2017_06_05
{
    class Program
    {
        static void Main(string[] args)
        {
            IEnumerable<string> elements = new List<string> { "Sport", "Lisboa", "e", "Benfica", "-", "tetra", "rumo", "ao", "penta" };
            IEnumerable<int> elemsQuery = elements
                .Where(s => s.Length > 3)
                .Select(s => s.Length)
                .Take(2);


                elemsQuery.ForEach(Console.WriteLine);
        }
    }
}
