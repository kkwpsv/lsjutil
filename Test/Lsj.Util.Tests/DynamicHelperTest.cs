using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lsj.Util.Tests
{
    [TestClass]
    public class DynamicHelperTest
    {
        [TestMethod]
        public void AutoCastAndAssignTest()
        {
            var str = "";
            Assert.IsTrue(DynamicHelper.AutoCastAndAssign(ref str, 123));
            Assert.AreEqual("123", str);

            var i = 0;
            Assert.IsTrue(DynamicHelper.AutoCastAndAssign(ref i, "123"));
            Assert.AreEqual(123, i);

            var d = 0m;
            Assert.IsTrue(DynamicHelper.AutoCastAndAssign(ref d, "123.45"));
            Assert.AreEqual(123.45m, d);
        }
    }
}
