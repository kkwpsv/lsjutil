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
            var parser = new JSONParser();
            Assert.IsNull(parser.Parse(""));
            Assert.IsNull(parser.Parse(null));
            Assert.AreEqual(0, parser.Parse<int>(""));
            Assert.AreEqual(0, parser.Parse<int>(null));

            var emptyObject = parser.Parse("{}");
            Assert.AreEqual(0, (emptyObject as JSONObject)!.GetDynamicMemberNames().Count());

            var obj = parser.Parse<TestObject>(@"{""C"":null}");
            Assert.IsNull(obj!.C);

            var emptyObject2 = parser.Parse("\r\n{\r\n}\r\n");
            Assert.AreEqual(0, (emptyObject2 as JSONObject)!.GetDynamicMemberNames().Count());
        }

        [TestMethod]
        public void Parse_Int()
        {
            var parser = new JSONParser();
            Assert.AreEqual(1, parser.Parse("1"));
            Assert.AreEqual(1, parser.Parse<int>("1"));
        }

        [TestMethod]
        public void Parse_Array()
        {
            var parser = new JSONParser();
            var result = parser.Parse<List<int>>("[0,1,2,3]");
            Assert.IsNotNull(result);
            Assert.HasCount(4, result);
            for (int i = 0; i < 4; i++)
            {
                Assert.AreEqual(i, result[i]);
            }

            var result2 = parser.Parse<List<int>>("[]");
            Assert.IsNotNull(result2);
            Assert.IsEmpty(result2);

            var result3 = parser.Parse("[]");
            Assert.IsNotNull(result3);
            Assert.IsInstanceOfType<JSONArray>(result3);
            Assert.AreEqual(0, result3!.Count);

            var result4 = parser.Parse<List<TestStruct>>(@"[{""A"":1},{""B"":2},{""C"":""ABC""}]");
            Assert.IsNotNull(result4);
            Assert.HasCount(3, result4);
            Assert.AreEqual(1, result4[0].A);
            Assert.AreEqual(2, result4[1].B);
            Assert.AreEqual("ABC", result4[2].C);
        }

        [TestMethod]
        public void Parse_Object()
        {
            var parser = new JSONParser();
            var result = parser.Parse<TestObject>(@"{""A"":1,""B"":2,""D"":4}");
            Assert.IsNotNull(result);
            Assert.AreEqual(1, result.A);
            Assert.AreEqual(2, result.B);
        }

        [TestMethod]
        public void Parse_Struct()
        {
            var parser = new JSONParser();
            var result = parser.Parse<TestStruct>(@"{""A"":1,""B"":2,""D"":4}");
            Assert.AreEqual(1, result.A);
            Assert.AreEqual(2, result.B);
        }

        [TestMethod]
        public void Parse_Custom()
        {
            var parser = new JSONParser();
            var result = parser.Parse<TestCustomObject>(@"{""A"":""Test"",""B"":""Test2""}");
            Assert.IsNotNull(result);
            Assert.AreEqual(true, result.A);
            Assert.AreEqual(false, result.B);
        }

        [TestMethod]
        public void Parse_Dynamic()
        {
            var parser = new JSONParser();
            var result = parser.Parse(@"{""A"":1,""B"":2,""D"":4}");
            int d1 = result!.D;
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
        public object Convert(object? obj) => throw new NotImplementedException();
        public object Parse(object? str) => (string?)str == "Test";
    }

    public class TestObject
    {
        public int A { get; set; }
        public int B { get; set; }
        public TestObject? C { get; set; }
    }

    public struct TestStruct
    {
        public int A { get; set; }
        public int B { get; set; }
        public string C { get; set; }
    }
}

