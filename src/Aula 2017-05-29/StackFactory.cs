using System;

namespace Aula_2017_05_29
{
    public class StackFactory
    {
        public static Stack<S> CreateStack<S>(int max) where S: IComparable<S>
        {
            return new Stack<S>(max);
        }


        void m1()
        {
            Stack<int> s1 = CreateStack<int>(10);
        }
    }
}