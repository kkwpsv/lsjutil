using Lsj.Util.JSON;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections.Generic;
using System.Dynamic;

namespace Lsj.Util.Tests.JSON
{
    [TestClass]
    public class JSONConverterTest
    {
        [TestMethod]
        public void Convert_Dictionary()
        {
            Assert.AreEqual(@"{""test"":1}", JSONConverter.ConvertToJSONString(new Dictionary<string, int> { { "test", 1 } }));
        }

        [TestMethod]
        public void Convert_ExpandoObject()
        {
            dynamic obj = new ExpandoObject();
            obj.test = 1;
            Assert.AreEqual(@"{""test"":1}", JSONConverter.ConvertToJSONString(obj));
        }
    }
}
