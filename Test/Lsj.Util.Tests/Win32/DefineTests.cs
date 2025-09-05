using Lsj.Util.Reflection;
using Lsj.Util.Win32;
using Lsj.Util.Win32.Attributes;
using Lsj.Util.Win32.ComInterfaces;
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
        private static List<string> newApis = new List<string>
        {
            "DXGIDisableVBlankVirtualization",
            "DXGIGetDebugInterface",
            "SetThreadCursorCreationScaling",
        };

        [TestMethod]
        public void TestEntryPoints()
        {
            var methods = typeof(Lsj.Util.Win32.Kernel32).Assembly.GetTypes().SelectMany(t => t.GetMethods()).Where(m => m.IsStatic && m.GetCustomAttribute<DllImportAttribute>() != null);
            var methodsToEntryPoints = methods.Select(m => (Method: m, Attribute: m.GetCustomAttribute<DllImportAttribute>())).OrderBy(x => x.Attribute.Value).ThenBy(x => x.Attribute.EntryPoint).ToList();
            var failed = new List<(MethodInfo Method, DllImportAttribute Attribute)>();
            foreach (var item in methodsToEntryPoints)
            {
                if (item.Method.Name == item.Attribute.EntryPoint || item.Method.Name + "W" == item.Attribute.EntryPoint ||
                    "K32" + item.Method.Name == item.Attribute.EntryPoint || "K32" + item.Method.Name + "W" == item.Attribute.EntryPoint)
                {
                    if (Kernel32.GetProcAddress(Kernel32.LoadLibrary(item.Attribute.Value), item.Attribute.EntryPoint) == IntPtr.Zero)
                    {
                        if (item.Attribute.Value == "Wlanapi.dll")
                        {
                            continue;
                        }
                        if (item.Attribute.Value.StartsWith("D3DX9"))
                        {
                            continue;
                        }
                        if (newApis.Contains(item.Attribute.EntryPoint))
                        {
                            continue;
                        }
                        failed.Add(item);
                    }
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

        [TestMethod]
        public void TestComInterfaces()
        {
            var iids = typeof(IIDs).GetFields();
            var interfaces = typeof(IUnknown).Assembly.GetTypes().Where(x => x.IsValueType && !x.IsEnum);

            var wrongIIDInterfaces = new List<Type>();
            var missingIIDInterfaces = new List<Type>();

            foreach (var @interface in interfaces)
            {
                if (@interface.GetCustomAttribute<ComInterfaceAttribute>() is ComInterfaceAttribute attribute)
                {
                    var iidField = iids.SingleOrDefault(x => x.Name == $"IID_{@interface.Name}");
                    if (iidField == null)
                    {
                        missingIIDInterfaces.Add(@interface);
                        continue;
                    }

                    if (!iidField.GetValue(null).ToString().Equals(attribute.IID, StringComparison.OrdinalIgnoreCase))
                    {
                        wrongIIDInterfaces.Add(@interface);
                    }
                }
            }

            if (missingIIDInterfaces.Any())
            {
                Assert.Fail(Environment.NewLine + string.Concat(missingIIDInterfaces.Select(item => $"{item.Name} missing IID in IIDs" + Environment.NewLine)));
            }

            if (wrongIIDInterfaces.Any())
            {
                Assert.Fail(Environment.NewLine + string.Concat(wrongIIDInterfaces.Select(item => $"{item.Name} has wrong IID" + Environment.NewLine)));
            }
        }
    }
}
