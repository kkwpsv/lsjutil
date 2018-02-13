using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lsj.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Diagnostics.CodeAnalysis;

namespace Lsj.Util.Tests
{
    [TestClass()]
    public class QuickBitConverterTests
    {
        [TestMethod()]
        public void ConvertToIntTest_Normal()
        {
            Assert.AreEqual(QuickBitConverter.ConvertToInt(new byte[] { 1, 2, 3, 4 }), 67305985);
        }
        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [ExcludeFromCodeCoverage]
        public void ConvertToIntTest_SrcTooShort()
        {
            QuickBitConverter.ConvertToInt(new byte[] { 1, 2, 3 });
        }
        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        [ExcludeFromCodeCoverage]
        public void ConvertToIntTest_SrcNull()
        {
            QuickBitConverter.ConvertToInt((byte[])null);
        }

        [TestMethod()]
        public void ConvertToIntTest_WithOffset_Normal()
        {
            Assert.AreEqual(QuickBitConverter.ConvertToInt(new byte[] { 1, 2, 3, 4, 5 }, 1), 84148994);
        }
        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [ExcludeFromCodeCoverage]
        public void ConvertToIntTest_WithOffset_SrcTooShort()
        {
            QuickBitConverter.ConvertToInt(new byte[] { 1, 2, 3 }, 1);
        }
        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [ExcludeFromCodeCoverage]
        public void ConvertToIntTest_WithOffset_OffsetTooLarge()
        {
            QuickBitConverter.ConvertToInt(new byte[] { 1, 2, 3, 4, 5 }, 2);
        }
        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [ExcludeFromCodeCoverage]
        public void ConvertToIntTest_WithOffset_OffsetLessThanZero()
        {
            QuickBitConverter.ConvertToInt(new byte[] { 1, 2, 3, 4, 5 }, -1);
        }
        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        [ExcludeFromCodeCoverage]
        public void ConvertToIntTest_WithOffset_SrcNull()
        {
            QuickBitConverter.ConvertToInt((byte[])null, 1);
        }

        [TestMethod()]
        public void ConvertToIntTest_Pointer_Normal()
        {
            unsafe
            {
                byte* buffer = stackalloc byte[4];
                buffer[0] = 1;
                buffer[1] = 2;
                buffer[2] = 3;
                buffer[3] = 4;
                Assert.AreEqual(QuickBitConverter.ConvertToInt(buffer), 67305985);
            }
        }
        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        [ExcludeFromCodeCoverage]
        public void ConvertToIntTest_Pointer_Null()
        {
            unsafe
            {
                QuickBitConverter.ConvertToInt(((byte*)null));
            }
        }

        [TestMethod()]
        public void ConvertToShortTest_Normal()
        {
            Assert.AreEqual(QuickBitConverter.ConvertToShort(new byte[] { 1, 2 }), 513);
        }
        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [ExcludeFromCodeCoverage]
        public void ConvertToShortTest_SrcTooShort()
        {
            QuickBitConverter.ConvertToShort(new byte[] { 1 });
        }
        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        [ExcludeFromCodeCoverage]
        public void ConvertToShortTest_SrcNull()
        {
            QuickBitConverter.ConvertToShort((byte[])null);
        }

        [TestMethod()]
        public void ConvertToShortTest_WithOffset_Normal()
        {
            Assert.AreEqual(QuickBitConverter.ConvertToShort(new byte[] { 1, 2, 3 }, 1), 770);
        }
        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [ExcludeFromCodeCoverage]
        public void ConvertToShortTest_WithOffset_SrcTooShort()
        {
            QuickBitConverter.ConvertToShort(new byte[] { 1 }, 1);
        }
        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [ExcludeFromCodeCoverage]
        public void ConvertToShortTest_WithOffset_OffsetTooLarge()
        {
            QuickBitConverter.ConvertToShort(new byte[] { 1, 2, 3 }, 2);
        }
        [TestMethod()]
        [ExpectedException(typeof(ArgumentOutOfRangeException))]
        [ExcludeFromCodeCoverage]
        public void ConvertToShortTest_WithOffset_OffsetLessThanZero()
        {
            QuickBitConverter.ConvertToShort(new byte[] { 1, 2, 3 }, -1);
        }
        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        [ExcludeFromCodeCoverage]
        public void ConvertToShortTest_WithOffset_SrcNull()
        {
            QuickBitConverter.ConvertToShort((byte[])null, 1);
        }

        [TestMethod()]
        public void ConvertToShortTest_Pointer_Normal()
        {
            unsafe
            {
                byte* buffer = stackalloc byte[4];
                buffer[0] = 1;
                buffer[1] = 2;
                Assert.AreEqual(QuickBitConverter.ConvertToShort(buffer), 513);
            }
        }
        [TestMethod()]
        [ExpectedException(typeof(ArgumentNullException))]
        [ExcludeFromCodeCoverage]
        public void ConvertToShortTest_Pointer_Null()
        {
            unsafe
            {
                QuickBitConverter.ConvertToShort(((byte*)null));
            }
        }

        [TestMethod()]
        public void ConvertToBytesTest_Int()
        {
            var result = QuickBitConverter.ConvertToBytes(67305985);
            Assert.AreEqual(result[0], 1);
            Assert.AreEqual(result[1], 2);
            Assert.AreEqual(result[2], 3);
            Assert.AreEqual(result[3], 4);
        }

        [TestMethod()]
        public void ConvertToBytesTest_Short()
        {
            var result = QuickBitConverter.ConvertToBytes((short)513);
            Assert.AreEqual(result[0], 1);
            Assert.AreEqual(result[1], 2);
        }
    }
}