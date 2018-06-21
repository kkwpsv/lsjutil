using Lsj.Util.JSON;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Text;

namespace Lsj.Util.Tests.JSON
{
    [TestClass]
    public class JSONParserTest
    {
        [TestMethod]
        public void Parse_Int()
        {
            Assert.AreEqual(1, JSONParser.Parse("1"));
            Assert.AreEqual(1, JSONParser.Parse<int>("1"));
        }

        [TestMethod]
        public void Parse_Array()
        {
            var result = JSONParser.Parse<List<int>>("[0,1,2,3]");
            Assert.AreEqual(4, result.Count);
            for (int i = 0; i < 4; i++)
            {
                Assert.AreEqual(i, result[i]);
            }

            var result2 = JSONParser.Parse<List<int>>("[]");
            Assert.AreEqual(0, result2.Count);
        }
    }
}
