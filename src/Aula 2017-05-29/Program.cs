using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula_2017_05_29
{
    class Program
    {
        static void Main(string[] args)
        {

            Stack<String> ss = new Stack<string>(10);
            ss.Push("A");
            ss.Push("dobradinha");
            ss.Push("já");
            ss.Push("cá");
            ss.Push("mora!");

            Console.WriteLine(ss);

            Stack<int> si = ss.Create(s => s.Length);

            Console.WriteLine(si);
        }
    }
}
