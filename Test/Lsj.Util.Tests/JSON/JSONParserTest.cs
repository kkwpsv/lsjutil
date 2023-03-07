using Lsj.Util.JSON;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace Lsj.Util.Tests.JSON
{
    [TestClass]
    public class JSONParserTest
    {
        [TestMethod]
        public void Parse_EmptyAndNull()
        {
            Assert.AreEqual<JSONObject>(null, JSONParser.Parse(""));
            Assert.AreEqual<JSONObject>(null, JSONParser.Parse(null));
            Assert.AreEqual(0, JSONParser.Parse<int>(""));
            Assert.AreEqual(0, JSONParser.Parse<int>(null));

            var emptyObject = JSONParser.Parse("{}");
            Assert.AreEqual(0, (emptyObject as JSONObject).GetDynamicMemberNames().Count());

            var obj = JSONParser.Parse<TestObject>(@"{""C"":null}");
            Assert.AreEqual(null, obj.C);

            var emptyObject2 = JSONParser.Parse("\r\n{\r\n}\r\n");
            Assert.AreEqual(0, (emptyObject2 as JSONObject).GetDynamicMemberNames().Count());
        }

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

            var result3 = JSONParser.Parse("[]");
            Assert.AreEqual(typeof(JSONArray), result3.GetType());
            Assert.AreEqual(0, result3.Count);

            var result4 = JSONParser.Parse<List<TestStruct>>(@"[{""A"":1},{""B"":2},{""C"":""ABC""}]");
            Assert.AreEqual(3, result4.Count);
            Assert.AreEqual(1, result4[0].A);
            Assert.AreEqual(2, result4[1].B);
            Assert.AreEqual("ABC", result4[2].C);
        }

        [TestMethod]
        public void Parse_Object()
        {
            var result = JSONParser.Parse<TestObject>(@"{""A"":1,""B"":2,""D"":4}");
            Assert.AreEqual(1, result.A);
            Assert.AreEqual(2, result.B);
        }

        [TestMethod]
        public void Parse_Struct()
        {
            var result = JSONParser.Parse<TestStruct>(@"{""A"":1,""B"":2,""D"":4}");
            Assert.AreEqual(1, result.A);
            Assert.AreEqual(2, result.B);
        }
        [TestMethod]
        public void Parse_Custom()
        {
            var result = JSONParser.Parse<TestCustomObject>(@"{""A"":""Test"",""B"":""Test2""}");
            Assert.AreEqual(true, result.A);
            Assert.AreEqual(false, result.B);
        }

        [TestMethod]
        public void Parse_Dynamic()
        {
            var result = JSONParser.Parse(@"{""A"":1,""B"":2,""D"":4}");
            int d1 = result.D;
            decimal d2 = result.D;
            Assert.AreEqual(1, result.A);
            Assert.AreEqual(2, result.B);
            Assert.AreEqual(4, d1);
            Assert.AreEqual(4m, d2);
        }
    }

    public class TestCustomObject
    {
        [CustomSerialize(Serializer = typeof(TestSerializer), SourceType = typeof(string))]
        public bool A { get; set; }
        [CustomSerialize(Serializer = typeof(TestSerializer), SourceType = typeof(string))]
        public bool B { get; set; }
    }

    public class TestSerializer : ISerializer
    {
        public object Convert(object obj) => throw new NotImplementedException();
        public object Parse(object str) => (string)str == "Test";
    }

    public class TestObject
    {
        public int A { get; set; }
        public int B { get; set; }
        public TestObject C { get; set; }
    }

    public struct TestStruct
    {
        public int A { get; set; }
        public int B { get; set; }
        public string C { get; set; }
    }
}

