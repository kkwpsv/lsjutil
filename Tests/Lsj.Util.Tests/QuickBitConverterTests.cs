using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lsj.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics.CodeAnalysis;

namespace Lsj.Util.Tests
{
    [TestClass]
    public class QuickBitConverterTests
    {
        [TestMethod]
        [ExcludeFromCodeCoverage]
        public void ConvertToIntTest()
        {
            Assert.AreEqual(QuickBitConverter.ConvertToInt(new byte[] { 1, 2, 3, 4 }), 67305985);
            Assert.AreEqual(QuickBitConverter.ConvertToInt(new byte[] { 1, 2, 3, 4, 5 }, 1), 84148994);
            try
            {
                QuickBitConverter.ConvertToInt(new byte[] { 1, 2, 3 });
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(ArgumentOutOfRangeException));
            }
            try
            {
                QuickBitConverter.ConvertToInt(new byte[] { 1, 2, 3 }, 1);
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(ArgumentOutOfRangeException));
            }
            try
            {
                QuickBitConverter.ConvertToInt(new byte[] { 1, 2, 3, 4, 5 }, 2);
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(ArgumentOutOfRangeException));
            }
            try
            {
                QuickBitConverter.ConvertToInt(new byte[] { 1, 2, 3, 4, 5 }, -1);
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(ArgumentOutOfRangeException));
            }
            try
            {
                QuickBitConverter.ConvertToInt((byte[])null);
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(ArgumentNullException));
            }
            try
            {
                QuickBitConverter.ConvertToInt(null, 1);
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(ArgumentNullException));
            }
            unsafe
            {
                byte* buffer = stackalloc byte[4];
                buffer[0] = 1;
                buffer[1] = 2;
                buffer[2] = 3;
                buffer[3] = 4;
                Assert.AreEqual(QuickBitConverter.ConvertToInt(buffer), 67305985);
                try
                {
                    QuickBitConverter.ConvertToInt(((byte*)null));
                }
                catch (Exception e)
                {
                    Assert.IsInstanceOfType(e, typeof(ArgumentNullException));
                }
            }
        }

        [TestMethod]
        [ExcludeFromCodeCoverage]
        public void ConvertToShortTest()
        {
            Assert.AreEqual(QuickBitConverter.ConvertToShort(new byte[] { 1, 2 }), 513);
            Assert.AreEqual(QuickBitConverter.ConvertToShort(new byte[] { 1, 2, 3 }, 1), 770);
            try
            {
                QuickBitConverter.ConvertToShort(new byte[] { 1 });
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(ArgumentOutOfRangeException));
            }
            try
            {
                QuickBitConverter.ConvertToShort(new byte[] { 1 }, 1);
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(ArgumentOutOfRangeException));
            }
            try
            {
                QuickBitConverter.ConvertToShort(new byte[] { 1, 2, 3 }, 2);
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(ArgumentOutOfRangeException));
            }
            try
            {
                QuickBitConverter.ConvertToShort(new byte[] { 1, 2, 3 }, -1);
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(ArgumentOutOfRangeException));
            }
            try
            {
                QuickBitConverter.ConvertToShort((byte[])null);
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(ArgumentNullException));
            }
            try
            {
                QuickBitConverter.ConvertToShort(null, 1);
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(ArgumentNullException));
            }
            unsafe
            {
                byte* buffer = stackalloc byte[4];
                buffer[0] = 1;
                buffer[1] = 2;
                Assert.AreEqual(QuickBitConverter.ConvertToShort(buffer), 513);
                try
                {
                    QuickBitConverter.ConvertToShort(((byte*)null));
                }
                catch (Exception e)
                {
                    Assert.IsInstanceOfType(e, typeof(ArgumentNullException));
                }
            }
        }

        [TestMethod]
        public void ConvertToBytesTest()
        {
            var result = QuickBitConverter.ConvertToBytes(67305985);
            Assert.AreEqual(result[0], 1);
            Assert.AreEqual(result[1], 2);
            Assert.AreEqual(result[2], 3);
            Assert.AreEqual(result[3], 4);
            result = QuickBitConverter.ConvertToBytes((short)513);
            Assert.AreEqual(result[0], 1);
            Assert.AreEqual(result[1], 2);
        }
    }
}