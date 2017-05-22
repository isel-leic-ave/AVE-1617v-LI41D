


using System;
using System.Security.Cryptography;
using Aula_2017_05_22;

namespace Aula2017_05_22
{
    class Program
    {


        static void Main(string[] args)
        {
            Stack<int> sInt = new Stack<int>(10);
            sInt.Push(1);sInt.Push(3);sInt.Push(2);sInt.Push(5);

            

            int maxInt = sInt.Max();
            Console.WriteLine(maxInt);

            Stack<string> sStr = new Stack<string>(10);


            sStr.Push("aa"); sStr.Push("c"); sStr.Push("b"); sStr.Push("d");

            string maxStr = sStr.Max();
            Console.WriteLine(maxStr);


            string maxStr1 = sStr.Max((s1,s2) => s1.Length - s2.Length);
            Console.WriteLine(maxStr1);


        }
    }
}
