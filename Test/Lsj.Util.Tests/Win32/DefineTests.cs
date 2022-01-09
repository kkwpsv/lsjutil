using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Linq;
using System.Reflection;
using System.Runtime.InteropServices;

namespace Lsj.Util.Tests.Win32
{
    [TestClass]
    public class DefineTests
    {
        [TestMethod]
        public void TestEntryPoints()
        {
            var methods = typeof(Lsj.Util.Win32.Kernel32).Assembly.GetTypes().SelectMany(t => t.GetMethods()).Where(m => m.IsStatic && m.GetCustomAttribute<DllImportAttribute>() != null);
            var methodsToEntryPoints = methods.Select(m => (Method: m, Attribute: m.GetCustomAttribute<DllImportAttribute>())).ToList();
            var failed = new List<(MethodInfo Method, DllImportAttribute Attribute)>();
            foreach (var item in methodsToEntryPoints)
            {
                if (item.Method.Name == item.Attribute.EntryPoint || item.Method.Name + "W" == item.Attribute.EntryPoint)
                {

                }
                else
                {
                    failed.Add(item);
                }
            }
            if (failed.Any())
            {
                Assert.Fail(Environment.NewLine + string.Concat(failed.Select(item => $"{item.Method.DeclaringType.Name} {item.Method.Name} entrypoint error." + Environment.NewLine)));
            }
        }

        [TestMethod]
        public void TestBlittableStructs()
        {
            var structs = typeof(Lsj.Util.Win32.Kernel32).Assembly.GetTypes().Where(x => x.IsValueType && !x.IsEnum);
            var wrongLayoutStructs = new List<Type>();
            var wrongFieldsStructs = new List<(Type type, List<FieldInfo> fields)>();
            foreach (var @struct in structs)
            {
                if (!@struct.IsLayoutSequential && !@struct.IsExplicitLayout)
                {
                    wrongLayoutStructs.Add(@struct);
                }

                var fields = @struct.GetFields(BindingFlags.Instance | BindingFlags.Public | BindingFlags.NonPublic);
                var wrongFields = fields.Where(x => (!x.FieldType.IsValueType && !x.FieldType.IsPointer) || x.FieldType.IsArray || x.GetCustomAttribute<MarshalAsAttribute>() != null);
                if (wrongFields.Any())
                {
                    wrongFieldsStructs.Add((@struct, wrongFields.ToList()));
                }
            }

            if (wrongLayoutStructs.Any())
            {
                Assert.Fail(Environment.NewLine + string.Concat(wrongLayoutStructs.Select(item => $"{item.Name} layout wrong" + Environment.NewLine)));
            }

            if (wrongFieldsStructs.Any())
            {
                Assert.Fail(Environment.NewLine + string.Concat(wrongFieldsStructs.Select(item => $"{item.type.Name} has wrong fields: {string.Join(" ", item.fields.Select(x => x.Name))}" + Environment.NewLine)));
            }
        }
    }
}
