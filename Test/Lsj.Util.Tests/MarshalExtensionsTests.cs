using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Runtime.InteropServices;

namespace Lsj.Util.Tests
{
    [TestClass]
    public class MarshalExtensionsTests
    {
        [StructLayout(LayoutKind.Sequential)]
        public struct TestStruct
        {
            public IntPtr A;
            public int B;
        }

        [TestMethod]
        public void SizeOfTest()
        {
            Assert.AreEqual(MarshalExtensions.SizeOf<int>(), 4);
            Assert.AreEqual(MarshalExtensions.SizeOf<IntPtr>(), IntPtr.Size);
            Assert.AreEqual(MarshalExtensions.SizeOf<TestStruct>(), 2* IntPtr.Size);
        }

        [TestMethod]
        public void Test()
        {
            var @struct = new TestStruct { A = (IntPtr)1, B = 1 };
            var ptr = MarshalExtensions.StructureToPtr(@struct);
            Assert.AreEqual(Marshal.ReadIntPtr(ptr), (IntPtr)1);
            Assert.AreEqual(Marshal.ReadInt32(ptr + IntPtr.Size), 1);
            Marshal.FreeHGlobal(ptr);
        }
    }
}