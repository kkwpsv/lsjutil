using Lsj.Util.AspNet.Core.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lsj.Util.Tests.AspNetCore.Validation
{
    [TestClass]
    public class QQAttributeTest
    {
        [TestMethod]
        public void QQ()
        {
            var attribute = new QQAttribute();
            Assert.AreEqual(true, attribute.IsValid("10000"));
            Assert.AreEqual(true, attribute.IsValid("3000000000"));
            Assert.AreEqual(false, attribute.IsValid("1"));
            Assert.AreEqual(false, attribute.IsValid("9999"));
            Assert.AreEqual(false, attribute.IsValid("99999999999"));
            Assert.AreEqual(true, attribute.IsValid(null));
        }
    }
}
