
using System;

namespace HelloWorld
{
    public class Program : Object
    {
		int x;
		public Program(int x) : base()
		{
			this.x = x;
		}
		
		private string sayHelloAndMoreStuff(string msg1, string msg2) {
			Console.WriteLine(msg1);
			Console.WriteLine(msg2);
			return msg1 + msg2;
			
		}
		
        public static void Main(string[] args)
        {
            Console.WriteLine("Hello World1!");
			
			Program p = new Program(5);
			string s = p.sayHelloAndMoreStuff("Hello World!", "Hello other planets also");
			Console.WriteLine(s);
			
        }
    }
}
