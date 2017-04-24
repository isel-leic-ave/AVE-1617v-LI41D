using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula_2017_04_17
{
    [AttributeUsage(AttributeTargets.Assembly)]
    class MyAssemblyAttribute : Attribute
    {
        public String MyProperty { get; set; }
    }
}
