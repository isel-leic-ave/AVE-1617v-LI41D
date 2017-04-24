using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading.Tasks;

namespace Aula_2017_04_17
{
    class Program
    {
        private String _name1;
        private String _name2;

        public String Name1
        {
            get { return _name1; }
            set { _name1 = value; }
        }

        public String get_Name2()
        {
             return _name2;
        }

        public void set_Name2(String value)
        {
            _name2 = value;
        }


        public String Name1Upper
        {
            get { return _name1.ToUpper(); }
        }

        public String ThNumberOne
        {
            get { return "SLB"; }
        }

        public String Name { get; set; } // Serve apenas para o programador ser calão!!!

        public void M1() { }
        //public int M1() { }
        public void M1(int x) { }

        static void Main(string[] args)
        {
            Program p = new Program();
            p.M1();
            p.get_Name2();
        }
    }
}
