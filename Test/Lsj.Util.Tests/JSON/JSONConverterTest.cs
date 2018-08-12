using Lsj.Util.JSON;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
    }
}
