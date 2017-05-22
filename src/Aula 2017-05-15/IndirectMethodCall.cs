using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula_2017_05_15
{
    class IndirectMethodCall
    {

        delegate int BinaryOperationDelegate(int x, int y);


        public static void Main(string[] args)
        {
            int res1 = OperateV1(2, 3, '+');

            int res2 = OperateV2(2, 3, new AddOper());

            BinaryOperationDelegate boAdd = new BinaryOperationDelegate(Add);

            int res = OperateV3(2,3, boAdd);
            

            boAdd(5, 6);

        }

        private static int OperateV1(int v1, int v2, char c)
        {
            switch (c)
            {
                case '+': return Add(v1,v2);
                case '-': return Sub(v1,v2);
                case '*': return Mul(v1, v2);
                case '/': return Div(v1, v2);
                default: throw new ArgumentException("Invalid operator");
            }            
        }

        private static int OperateV2(int v1, int v2, BinaryOperation o)
        {
            return o.Oper(v1, v2);
        }

        private static int OperateV3(int v1, int v2, BinaryOperationDelegate del)
        {
            return del(v1, v2);
        }

        private static int Add(int v1, int v2)
        {
            return v1 + v2;
        }

        private static int Sub(int v1, int v2)
        {
            return v1 - v2;
        }

        private static int Mul(int v1, int v2)
        {
            return v1 * v2;
        }

        private static int Div(int v1, int v2)
        {
            return v1 / v2;
        }

        private interface BinaryOperation
        {
            int Oper(int v1, int v2);
        }

        private class AddOper : BinaryOperation
        {
            public int Oper(int v1, int v2)
            {
                return Add(v1, v2);
            }
        }
    }
}
