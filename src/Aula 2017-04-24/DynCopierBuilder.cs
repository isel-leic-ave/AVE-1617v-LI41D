using System;
using System.Reflection;
using System.Reflection.Emit;

namespace Aula_2017_04_24
{
    internal class DynCopierBuilder
    {
        //public static ICopier Create(Type from, Type to)
        public static ICopier Create<TSrc, TDest>()
        {
            const string asmName = "DynamicCopier";
            AssemblyBuilder asm = CreateAsm(asmName);
            ModuleBuilder mb = asm.DefineDynamicModule(asmName, asmName + ".dll");

            TypeBuilder typeBuilder = mb.DefineType("DynamicCopier", TypeAttributes.Public, typeof(object), new Type[] {typeof(ICopier)});
            MethodBuilder methodBuilder = typeBuilder.DefineMethod(
                "Copy",
                MethodAttributes.Virtual | MethodAttributes.Public | MethodAttributes.ReuseSlot,
                typeof(void),
                new Type[] { typeof(TSrc), typeof(TDest)}
            );

            ILGenerator ilGenerator = methodBuilder.GetILGenerator();
            FieldInfo[] fieldsFrom = typeof(TSrc).GetFields(BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance);
            

            for (int i = 0; i < fieldsFrom.Length; i++)
            {
                ilGenerator.Emit(OpCodes.Ldarg_2);
                ilGenerator.Emit(OpCodes.Ldarg_1);
                ilGenerator.Emit(OpCodes.Ldfld, fieldsFrom[i]);
                ilGenerator.Emit(OpCodes.Stfld, typeof(TDest).GetField(fieldsFrom[i].Name, BindingFlags.NonPublic | BindingFlags.Public | BindingFlags.Instance));
            }
            ilGenerator.Emit(OpCodes.Ret);

            Type dynCipierType = typeBuilder.CreateType();
            ICopier dynCopier = (ICopier) Activator.CreateInstance(dynCipierType);

            asm.Save(asmName + ".dll");

            return dynCopier;
        }

        private static AssemblyBuilder CreateAsm(string name)
        {
            AssemblyName aName = new AssemblyName(name);

            AssemblyBuilder ab =
                AssemblyBuilder.DefineDynamicAssembly(
                    aName,
                    AssemblyBuilderAccess.RunAndSave);
            return ab;
        }
    }
}