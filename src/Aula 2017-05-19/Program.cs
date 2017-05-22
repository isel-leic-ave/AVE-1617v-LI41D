using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula_2017_05_19
{
    class Program
    {
        static void Main(string[] args)
        {

            IntStack sInt0 = new IntStack(10);



            Stack<int> sInt = new Stack<int>(5);

            sInt.Push(5);
            //sInt.Push("5");

            Stack<String> sStr = new Stack<String>(5);
            //sStr.Push(5);
            sStr.Push("5");

            ObjectStack sInt1 = new ObjectStack(5);
            sInt1.Push(5);
            int val = (int)sInt1.Pop();

            sInt1.Push("5");


            ObjectStack sStr1 = new ObjectStack(5);
            sStr1.Push("5");
            sStr1.Push(1);
            string strVal = (string)sStr1.Pop();


        }
    }
}
