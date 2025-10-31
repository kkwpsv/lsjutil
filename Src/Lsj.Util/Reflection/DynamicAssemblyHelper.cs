using System;
using System.Reflection;
using System.Reflection.Emit;
using System.Xml.Serialization;

namespace Lsj.Util.Reflection
{
    /// <summary>
    /// Dynamic assembly helper
    /// </summary>
    public static class DynamicAssemblyHelper
    {
        static ModuleBuilder _moduleBuilder;

        static DynamicAssemblyHelper()
        {
            var assemblyName = "Lsj.Util.DynamicAssembly";
            AssemblyBuilder assermblyBuilder = AssemblyBuilder.DefineDynamicAssembly(new AssemblyName(assemblyName), AssemblyBuilderAccess.Run);
            _moduleBuilder = assermblyBuilder.DefineDynamicModule(assemblyName);
        }

        /// <summary>
        /// Get the module builder
        /// </summary>
        public static ModuleBuilder ModuleBuilder => _moduleBuilder;

        /// <summary>
        /// Define type
        /// </summary>
        /// <param name="name"></param>
        /// <param name="typeAttributes"></param>
        /// <param name="parent"></param>
        /// <returns></returns>
        public static TypeBuilder DefineType(string name, TypeAttributes typeAttributes = TypeAttributes.NotPublic, Type? parent = null)
        {
            return ModuleBuilder.DefineType(name, typeAttributes, parent);
        }

        /// <summary>
        /// Define a delegate
        /// </summary>
        /// <param name="name"></param>
        /// <param name="retType"></param>
        /// <param name="parameterTypes"></param>
        /// <returns></returns>
        public static TypeBuilder DefineDelegate(string name, Type retType, Type[] parameterTypes)
        {
            var builder = ModuleBuilder.DefineType(name, TypeAttributes.Class | TypeAttributes.Public | TypeAttributes.Sealed, typeof(MulticastDelegate));
            builder.DefineConstructor(MethodAttributes.RTSpecialName | MethodAttributes.HideBySig | MethodAttributes.Public,
                CallingConventions.Standard, [typeof(object), typeof(IntPtr)]).SetImplementationFlags(MethodImplAttributes.Runtime | MethodImplAttributes.Managed);
            builder.DefineMethod("Invoke", MethodAttributes.Public | MethodAttributes.HideBySig | MethodAttributes.NewSlot | MethodAttributes.Virtual,
                retType, parameterTypes).SetImplementationFlags(MethodImplAttributes.Runtime | MethodImplAttributes.Managed);
            return builder;
        }
    }
}
