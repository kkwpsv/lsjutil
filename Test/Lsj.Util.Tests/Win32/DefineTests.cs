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
    }
}
