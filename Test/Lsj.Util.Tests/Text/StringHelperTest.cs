using System;
using System.Text;
using Lsj.Util.Text;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lsj.Util.Tests.Text
{
    [TestClass]
    public class StringHelperTest
    {
        private readonly string Test_abc = "abc";
        private readonly string Test_abcdefghi = "abcdefghi";

        [TestMethod]
        public void SubstringIgnoreOverFlowTest()
        {
            Assert.AreEqual("", Test_abc.SubstringIgnoreOverFlow(0, 0));
            Assert.AreEqual("bc", Test_abc.SubstringIgnoreOverFlow(1, 3));
            Assert.AreEqual("", Test_abc.SubstringIgnoreOverFlow(4, 0));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => Test_abc.SubstringIgnoreOverFlow(-1, 1));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => Test_abc.SubstringIgnoreOverFlow(1, -1));
        }

        [TestMethod]
        public void RemoveTest()
        {
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => "".RemoveLastOne());
            Assert.AreEqual("ab", Test_abc.RemoveLastOne());

            Assert.AreEqual("a", Test_abc.RemoveLast(2));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => Test_abc.RemoveLast(-1));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => Test_abc.RemoveLast(4));

            Assert.AreEqual("ac", Test_abc.RemoveOne(1));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => Test_abc.RemoveOne(-1));
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => Test_abc.RemoveOne(3));

            var sb = new StringBuilder();
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => sb.RemoveLastOne());

            sb = new StringBuilder(Test_abc);
            sb.RemoveLastOne();
            Assert.AreEqual("ab", sb.ToString());

            sb = new StringBuilder(Test_abc);
            sb.RemoveLast(2);
            Assert.AreEqual("a", sb.ToString());

            sb = new StringBuilder(Test_abc);
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => sb.RemoveLast(-1));

            sb = new StringBuilder(Test_abc);
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => sb.RemoveLast(4));

            sb = new StringBuilder(Test_abc);
            sb.Remove(1);
            Assert.AreEqual("a", sb.ToString());

            sb = new StringBuilder(Test_abc);
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => sb.Remove(-1));

            sb = new StringBuilder(Test_abc);
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => sb.Remove(3));
        }

        [TestMethod]
        public void GetSurroundingCharsTest()
        {
            Assert.AreEqual("abcdefg", Test_abcdefghi.GetSurroundingChars(3, 3));
            Assert.AreEqual("abcdefgh", Test_abcdefghi.GetSurroundingChars(3, 4));
            Assert.AreEqual("bcdefghi", Test_abcdefghi.GetSurroundingChars(5, 4));
            unsafe
            {
                fixed (char* ptr = Test_abcdefghi)
                {
                    Assert.AreEqual("abcdefg", StringHelper.GetSurroundingChars(ptr, 9, 3, 3));
                    Assert.AreEqual("abcdefgh", StringHelper.GetSurroundingChars(ptr, 9, 3, 4));
                    Assert.AreEqual("bcdefghi", StringHelper.GetSurroundingChars(ptr, 9, 5, 4));
                }
            }
        }

    }
}
