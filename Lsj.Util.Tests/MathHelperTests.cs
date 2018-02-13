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
    public class MathHelperTests
    {
        [TestMethod()]
        public void IsNumericTest_Numeric()
        {
            Assert.AreEqual(typeof(int).IsNumeric(), true);
        }
        [TestMethod()]
        public void IsNumericTest_NotNumeric()
        {
            Assert.AreEqual(typeof(string).IsNumeric(), false);
        }

        [TestMethod()]
        public void ConvertToIntTest_LongNormal()
        {
            Assert.AreEqual(0L.ConvertToInt(), 0);
        }
        [TestMethod()]
        public void ConvertToIntTest_LongLargerThanMax()
        {
            Assert.AreEqual(long.MaxValue.ConvertToInt(1, 2), 2);
        }
        [TestMethod()]
        public void ConvertToIntTest_LongLessThanMin()
        {
            Assert.AreEqual(long.MinValue.ConvertToInt(1, 2), 1);
        }
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        [ExcludeFromCodeCoverage]
        public void ConvertToIntTest_LongMinLargerThanMax()
        {
            (0L).ConvertToInt(2, 1);
        }

        [TestMethod()]
        public void ConvertToIntTest_DecimalNormal()
        {
            Assert.AreEqual(0.9m.ConvertToInt(), 0);
        }
        [TestMethod()]
        public void ConvertToIntTest_DecimalLargerThanMax()
        {
            Assert.AreEqual(decimal.MaxValue.ConvertToInt(1, 2), 2);
        }
        [TestMethod()]
        public void ConvertToIntTest_DecimalLessThanMin()
        {
            Assert.AreEqual(decimal.MinValue.ConvertToInt(1, 2), 1);
        }
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        [ExcludeFromCodeCoverage]
        public void ConvertToIntTest_DecimalMinLargerThanMax()
        {
            (0m).ConvertToInt(2, 1);
        }

        [TestMethod()]
        public void ConvertToIntTest_DoubleNormal()
        {
            Assert.AreEqual(0.9d.ConvertToInt(), 0);
        }
        [TestMethod()]
        public void ConvertToIntTest_DoubleLargerThanMax()
        {
            Assert.AreEqual(double.MaxValue.ConvertToInt(1, 2), 2);
        }
        [TestMethod()]
        public void ConvertToIntTest_DoubleLessThanMin()
        {
            Assert.AreEqual(double.MinValue.ConvertToInt(1, 2), 1);
        }
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        [ExcludeFromCodeCoverage]
        public void ConvertToIntTest_DoubleMinLargerThanMax()
        {
            (0d).ConvertToInt(2, 1);
        }

        [TestMethod()]
        public void ConvertToLongTest_DecimalNormal()
        {
            Assert.AreEqual(0.9m.ConvertToLong(), 0);
        }
        [TestMethod()]
        public void ConvertToLongTest_DecimalLargerThanMax()
        {
            Assert.AreEqual(decimal.MaxValue.ConvertToLong(1, 2), 2);
        }
        [TestMethod()]
        public void ConvertToLongTest_DecimalLessThanMin()
        {
            Assert.AreEqual(decimal.MinValue.ConvertToInt(1, 2), 1);
        }
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        [ExcludeFromCodeCoverage]
        public void ConvertToLongTest_DecimalMinLargerThanMax()
        {
            (0m).ConvertToInt(2, 1);
        }

        [TestMethod()]
        public void ConvertToLongTest_DoubleNormal()
        {
            Assert.AreEqual(0.9d.ConvertToLong(), 0);
        }
        [TestMethod()]
        public void ConvertToLongTest_DoubleLargerThanMax()
        {
            Assert.AreEqual(double.MaxValue.ConvertToLong(1, 2), 2);
        }
        [TestMethod()]
        public void ConvertToLongTest_DoubleLessThanMin()
        {
            Assert.AreEqual(double.MinValue.ConvertToLong(1, 2), 1);
        }
        [TestMethod()]
        [ExpectedException(typeof(ArgumentException))]
        [ExcludeFromCodeCoverage]
        public void ConvertToLongTest_DoubleMinLargerThanMax()
        {
            (0d).ConvertToLong(2, 1);
        }

    }
}