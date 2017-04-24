using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Aula_2017_04_24
{
    using System;
    using System.Reflection;
    using System.Reflection.Emit;

    public interface IGetter
    {
        int GetNr();
    }

    class App
    {
        public static void Main()
        {
            IGetter getter = GetterBuilder.CreateDummyGetter(53);
            Console.WriteLine(getter.GetNr());
        }
    }
    class GetterBuilder
    {

        public static IGetter CreateDummyGetter(int seed)
        {
            const string asmName = "DynamicAssemblyExample";
            AssemblyBuilder asm = CreateAsm(asmName);
            ModuleBuilder mb = asm.DefineDynamicModule(asmName, asmName + ".dll");
            TypeBuilder tb = mb.DefineType(
                "MyDynamicType",
                TypeAttributes.Public,
                typeof(object),
                new Type[] { typeof(IGetter) });

            // Add a private field of type int (Int32).
            FieldBuilder fbNumber = tb.DefineField(
                "m_number",
                typeof(int),
                FieldAttributes.Private);

            AddCtor(tb, fbNumber);

            MethodBuilder getNrBuilder = tb.DefineMethod(
                "GetNr",
                MethodAttributes.Virtual | MethodAttributes.Public | MethodAttributes.ReuseSlot,
                typeof(int),
                Type.EmptyTypes);

            ILGenerator il = getNrBuilder.GetILGenerator();
            il.Emit(OpCodes.Ldarg_0);
            il.Emit(OpCodes.Ldfld, fbNumber);
            il.Emit(OpCodes.Ret);


            // Finish the type.
            Type t = tb.CreateType();
            asm.Save(asmName + ".dll");
            return (IGetter)Activator.CreateInstance(t, new object[] { seed });
        }

        private static void AddCtor(TypeBuilder tb, FieldInfo fbNumber)
        {
            // Define a constructor that takes an integer argument and 
            // stores it in the private field. 
            Type[] parameterTypes = { typeof(int) };
            ConstructorBuilder ctor1 = tb.DefineConstructor(
                MethodAttributes.Public,
                CallingConventions.Standard,
                parameterTypes);

            ILGenerator ctor1IL = ctor1.GetILGenerator();
            ctor1IL.Emit(OpCodes.Ldarg_0);
            ctor1IL.Emit(OpCodes.Call,
                typeof(object).GetConstructor(Type.EmptyTypes));
            // Push the instance on the stack before pushing the argument
            // that is to be assigned to the private field m_number.
            ctor1IL.Emit(OpCodes.Ldarg_0);
            ctor1IL.Emit(OpCodes.Ldarg_1);
            ctor1IL.Emit(OpCodes.Stfld, fbNumber);
            ctor1IL.Emit(OpCodes.Ret);
        }

        private static AssemblyBuilder CreateAsm(string name)
        {
            AssemblyName aName = new AssemblyName(name);
            AssemblyBuilder ab =
                AppDomain.CurrentDomain.DefineDynamicAssembly(
                    aName,
                    AssemblyBuilderAccess.RunAndSave);
            return ab;
        }
    }



    // Equivalent code generated
    class MyDynamicType : Object, IGetter
    {
        private int m_number;

        public MyDynamicType(int nr)
        {
            m_number = nr;
        }

        public virtual int GetNr()
        {
            return m_number;
        }
    }
}
