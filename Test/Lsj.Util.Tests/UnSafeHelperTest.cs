using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lsj.Util.Tests
{
    [TestClass]
    public class UnSafeHelperTest
    {
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
