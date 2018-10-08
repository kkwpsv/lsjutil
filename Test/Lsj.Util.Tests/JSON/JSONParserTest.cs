using Lsj.Util.JSON;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;

namespace Lsj.Util.Tests.JSON
{
    [TestClass]
    public class JSONParserTest
    {
        [TestMethod]
        public void Parse_EmptyAndNull()
        {
            Assert.AreEqual(null, JSONParser.Parse(""));
            Assert.AreEqual(null, JSONParser.Parse(null));
            Assert.AreEqual(0, JSONParser.Parse<int>(""));
            Assert.AreEqual(0, JSONParser.Parse<int>(null));
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
            var result = JSONParser.Parse<TestCustomObject>(@"{""A"":Test,""B"":""Test""}");
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
        [CustomSerialize(Serializer = typeof(TestSerializer))]
        public bool A { get; set; }
        [CustomSerialize(Serializer = typeof(TestSerializer))]
        public bool B { get; set; }
    }

    public class TestSerializer : ISerializer
    {
        public string Convert(object obj) => throw new NotImplementedException();
        public object Parse(string str) => str == "Test";
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
    }


}

