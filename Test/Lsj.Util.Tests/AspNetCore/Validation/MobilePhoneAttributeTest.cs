using Lsj.Util.AspNetCore.Validation;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lsj.Util.Tests.AspNetCore.Validation
{
    [TestClass]
    public class MobilePhoneAttributeTest
    {
        [TestMethod]
        public void MobilePhone()
        {
            var attribute = new MobilePhoneAttribute();
            Assert.AreEqual(true, attribute.IsValid("13333333333"));
            Assert.AreEqual(true, attribute.IsValid("16666666666"));
            Assert.AreEqual(false, attribute.IsValid("1"));
            Assert.AreEqual(true, attribute.IsValid(null));
        }
    }
}
