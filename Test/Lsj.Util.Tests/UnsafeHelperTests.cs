using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lsj.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.IO;
using System.Diagnostics.CodeAnalysis;

namespace Lsj.Util.Tests
{
    [TestClass]
    public class UnsafeHelperTests
    {
        [TestMethod]
        public void CopyTest()
        {
            var a = new byte[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10, 11, 12, 13, 14 };
            var b = new byte[] { 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0, 0 };
            UnsafeHelper.Copy(a, b, 15);
            for (int i = 0; i < 15; i++)
            {
                Assert.AreEqual(b[i], i);
            }
            UnsafeHelper.Copy(a, 2, b, 0, 2);
            Assert.AreEqual(b[0], 2);
            Assert.AreEqual(b[1], 3);
            unsafe
            {
                fixed (byte* b2 = b)
                {
                    UnsafeHelper.Copy(a, b2, 15);
                    for (int i = 0; i < 15; i++)
                    {
                        Assert.AreEqual(b[i], i);
                    }
                }
            }

            var aa = new char[] { '0', '1', '2', '3', '4', '5', '6' };
            var bb = new char[] { '0', '0', '0', '0', '0', '0', '0' };
            UnsafeHelper.Copy(aa, bb, 7);
            for (int i = 0; i < 7; i++)
            {
                Assert.AreEqual(bb[i], '0' + i);
            }
            UnsafeHelper.Copy(aa, 2, bb, 0, 2);
            Assert.AreEqual(bb[0], '2');
            Assert.AreEqual(bb[1], '3');
            unsafe
            {
                fixed (char* bb2 = bb)
                {
                    UnsafeHelper.Copy(aa, bb2, 7);
                    for (int i = 0; i < 7; i++)
                    {
                        Assert.AreEqual(bb[i], '0' + i);
                    }
                }
            }

            var aaa = new short[] { 0, 1, 2, 3, 4, 5, 6 };
            var bbb = new short[] { 0, 0, 0, 0, 0, 0, 0 };
            UnsafeHelper.Copy(aaa, bbb, 7);
            for (int i = 0; i < 7; i++)
            {
                Assert.AreEqual(bbb[i], i);
            }
            UnsafeHelper.Copy(aaa, 2, bbb, 0, 2);
            Assert.AreEqual(bbb[0], 2);
            Assert.AreEqual(bbb[1], 3);
            unsafe
            {
                fixed (short* bbb2 = bbb)
                {
                    UnsafeHelper.Copy(aaa, bbb2, 7);
                    for (int i = 0; i < 7; i++)
                    {
                        Assert.AreEqual(bbb[i], i);
                    }
                }
            }

            var aaaa = new int[] { 0, 1, 2 };
            var bbbb = new int[] { 0, 0, 0 };
            UnsafeHelper.Copy(aaaa, bbbb, 3);
            for (int i = 0; i < 3; i++)
            {
                Assert.AreEqual(bbbb[i], i);
            }
            UnsafeHelper.Copy(aaaa, 2, bbbb, 0, 1);
            Assert.AreEqual(bbbb[0], 2);
            unsafe
            {
                fixed (int* bbbb2 = bbbb)
                {
                    UnsafeHelper.Copy(aaaa, bbbb2, 3);
                    for (int i = 0; i < 3; i++)
                    {
                        Assert.AreEqual(bbbb[i], i);
                    }
                }
            }

            var aaaaa = new long[] { 0, 1, 2 };
            var bbbbb = new long[] { 0, 0, 0 };
            UnsafeHelper.Copy(aaaaa, bbbbb, 3);
            for (int i = 0; i < 3; i++)
            {
                Assert.AreEqual(bbbbb[i], i);
            }
            UnsafeHelper.Copy(aaaaa, 2, bbbbb, 0, 1);
            Assert.AreEqual(bbbbb[0], 2);
            unsafe
            {
                fixed (long* bbbbb2 = bbbbb)
                {
                    UnsafeHelper.Copy(aaaaa, bbbbb2, 3);
                    for (int i = 0; i < 3; i++)
                    {
                        Assert.AreEqual(bbbbb[i], i);
                    }
                }
            }
        }

        [TestMethod]
        public void ContactTest()
        {
            var nullBytes = new byte[0];
            var result = UnsafeHelper.Contact(nullBytes, nullBytes);
            Assert.AreEqual(0, result.Length);

            var bytes1 = new byte[] { 0, 1, 2, 3 };
            var bytes2 = new byte[] { 4, 5, 6 };
            result = UnsafeHelper.Contact(bytes1, bytes2);
            Assert.AreEqual(7, result.Length);
            for (int i = 0; i < 7; i++)
            {
                Assert.AreEqual(i, result[i]);
            }
        }
    }
}