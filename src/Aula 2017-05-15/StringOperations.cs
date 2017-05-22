using System;
using System.Text;

namespace Aula_2017_05_15
{
    public class StringOperations
    {
        delegate string StrProcessor(string str);

        static string Concat(string[] strs)
        {
            //StringBuilder sb = new StringBuilder();
            //foreach (var s in strs)
            //{
            //    sb.Append(s);
            //}

            //return sb.ToString();
            return Concat(strs, s => s);
        }

        static string ConcatFirstChar(string[] strs)
        {
            //StringBuilder sb = new StringBuilder();
            //foreach (var s in strs)
            //{
            //    sb.Append(s[0]);
            //}

            //return sb.ToString();
            return Concat(strs, s => s[0].ToString());
        }

        static string ConcatWithDelimiter(string[] strs, string delimiter)
        {
            //StringBuilder sb = new StringBuilder();
            //foreach (var s in strs)
            //{
            //    sb.Append(s + delimiter);
            //}

            //return sb.ToString();
            return Concat(strs, s => s + delimiter);
        }

        private static string Concat(string[] strs, StrProcessor processor)
        {
            StringBuilder sb = new StringBuilder();
            foreach (var s in strs)
            {
                sb.Append(processor(s));
            }

            return sb.ToString();
        }

        public static void Main(string[] args)
        {
            string[] strings = {"Sport", "Lisboa", "e", "Benfica", "Tetra", "Campeão"};
            string res = Concat(strings);
            Console.WriteLine(res);

            res = ConcatFirstChar(strings);
            Console.WriteLine(res);

            res = ConcatWithDelimiter(strings, "###");
            Console.WriteLine(res);
        }
    }

    
}