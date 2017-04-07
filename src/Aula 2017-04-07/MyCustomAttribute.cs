using System;

namespace Aula_2017_04_07
{
    [AttributeUsage(AttributeTargets.Property | AttributeTargets.Field, AllowMultiple = true)]
    public class RequiredAttribute : Attribute
    {
        public string DefaultValue { get; set; }
    }
}