using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Diagnostics.CodeAnalysis;

namespace Lsj.Util.Tests
{
    [TestClass]
    public class MathHelperTests
    {
        [TestMethod]
        [ExcludeFromCodeCoverage]
        public void IsNumericTest()
        {
            Assert.AreEqual(typeof(int).IsNumeric(), true);
            Assert.AreEqual(typeof(string).IsNumeric(), false);
            Assert.ThrowsExactly<ArgumentNullException>(() => { (null as Type).IsNumeric(); });
        }


        [TestMethod]
        [ExcludeFromCodeCoverage]
        public void ConvertToIntTest()
        {
            Assert.AreEqual(0L.ConvertToInt(), 0);
            Assert.AreEqual(long.MaxValue.ConvertToInt(1, 2), 2);
            Assert.AreEqual(long.MinValue.ConvertToInt(1, 2), 1);
            Assert.AreEqual(0.9m.ConvertToInt(), 0);
            Assert.AreEqual(decimal.MaxValue.ConvertToInt(1, 2), 2);
            Assert.AreEqual(decimal.MinValue.ConvertToInt(1, 2), 1);
            Assert.AreEqual(0.9d.ConvertToInt(), 0);
            Assert.AreEqual(double.MaxValue.ConvertToInt(1, 2), 2);
            Assert.AreEqual(double.MinValue.ConvertToInt(1, 2), 1);
            try
            {
                (0L).ConvertToInt(2, 1);
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(ArgumentException));
            }
            try
            {
                (0m).ConvertToInt(2, 1);
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(ArgumentException));
            }
            try
            {
                (0d).ConvertToInt(2, 1);
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(ArgumentException));
            }
        }

        [TestMethod]
        [ExcludeFromCodeCoverage]
        public void ConvertToLongTest()
        {
            Assert.AreEqual(0.9m.ConvertToLong(), 0);
            Assert.AreEqual(decimal.MaxValue.ConvertToLong(1, 2), 2);
            Assert.AreEqual(decimal.MinValue.ConvertToLong(1, 2), 1);
            Assert.AreEqual(0.9d.ConvertToLong(), 0);
            Assert.AreEqual(double.MaxValue.ConvertToLong(1, 2), 2);
            Assert.AreEqual(double.MinValue.ConvertToLong(1, 2), 1);
            try
            {
                (0m).ConvertToLong(2, 1);
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(ArgumentException));
            }
            try
            {
                (0d).ConvertToLong(2, 1);
            }
            catch (Exception e)
            {
                Assert.IsInstanceOfType(e, typeof(ArgumentException));
            }
        }
    }
}