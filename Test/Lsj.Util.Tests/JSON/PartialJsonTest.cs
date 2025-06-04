using Lsj.Util.JSON;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using static Lsj.Util.Tests.JSON.JSONConverterTest;

namespace Lsj.Util.Tests.JSON
{
    [TestClass]
    public class PartialJsonTest
    {
        [TestMethod]
        public void Parse_PartialJsonSimple()
        {
            var parser = new JSONParser();
            parser.Settings.AllowPartial = true;
            Assert.AreEqual("", parser.Parse(@""""));
            Assert.AreEqual(false, parser.IsLastParseComplete);

            Assert.AreEqual("12345", parser.Parse(@"""12345"));
            Assert.AreEqual(false, parser.IsLastParseComplete);

            Assert.AreEqual(12345m, parser.Parse(@"12345."));
            Assert.AreEqual(true, parser.IsLastParseComplete);

            var obj = parser.Parse(@"{");
            Assert.AreEqual(true, obj is JSONObject);
            Assert.AreEqual(0, (obj as JSONObject).GetDynamicMemberNames().Count());
            Assert.AreEqual(false, parser.IsLastParseComplete);

            var testObj = parser.Parse<TestObject>(@"{");
            Assert.IsNotNull(testObj);
            Assert.AreEqual(0, testObj.A);
            Assert.AreEqual(0, testObj.B);
            Assert.IsNull(testObj.C);
            Assert.AreEqual(false, parser.IsLastParseComplete);

            var array = parser.Parse(@"[");
            Assert.AreEqual(true, array is JSONArray);
            Assert.AreEqual(0, (array as JSONArray).Count);
            Assert.AreEqual(false, parser.IsLastParseComplete);

            Assert.AreEqual(true, parser.Parse(@"tr "));
            Assert.AreEqual(false, parser.IsLastParseComplete);
            Assert.AreEqual(true, parser.Parse(@"true"));
            Assert.AreEqual(true, parser.IsLastParseComplete);
            Assert.ThrowsException<JSONParserException>(() => parser.Parse(@"tra"));

            Assert.AreEqual(false, parser.Parse(@"fal   "));
            Assert.AreEqual(false, parser.IsLastParseComplete);
            Assert.AreEqual(false, parser.Parse(@"false"));
            Assert.AreEqual(true, parser.IsLastParseComplete);
            Assert.ThrowsException<JSONParserException>(() => parser.Parse(@"falss"));

            Assert.IsNull(parser.Parse(@"nul   "));
            Assert.AreEqual(false, parser.IsLastParseComplete);
            Assert.IsNull(parser.Parse(@"null"));
            Assert.AreEqual(true, parser.IsLastParseComplete);
        }

        [TestMethod]
        public void Parse_PartialJsonArray()
        {
            var parser = new JSONParser();
            parser.Settings.AllowPartial = true;

            var jsonArray1 = parser.Parse(@"[""abc"",""abcd""]") as JSONArray;
            Assert.IsNotNull(jsonArray1);
            Assert.AreEqual(2, jsonArray1.Count);
            Assert.AreEqual("abc", jsonArray1[0]);
            Assert.AreEqual("abcd", jsonArray1[1]);
            Assert.AreEqual(true, parser.IsLastParseComplete);

            var jsonArray2 = parser.Parse(@"[""abc"",""ab") as JSONArray;
            Assert.IsNotNull(jsonArray2);
            Assert.AreEqual(2, jsonArray2.Count);
            Assert.AreEqual("abc", jsonArray2[0]);
            Assert.AreEqual("ab", jsonArray2[1]);
            Assert.AreEqual(false, parser.IsLastParseComplete);

            var jsonArray3 = parser.Parse(@"[""abc"",") as JSONArray;
            Assert.IsNotNull(jsonArray3);
            Assert.AreEqual(1, jsonArray3.Count);
            Assert.AreEqual("abc", jsonArray3[0]);
            Assert.AreEqual(false, parser.IsLastParseComplete);

            var jsonArray4 = parser.Parse(@"[true,false,tru") as JSONArray;
            Assert.IsNotNull(jsonArray4);
            Assert.AreEqual(3, jsonArray4.Count);
            Assert.AreEqual(true, jsonArray4[0]);
            Assert.AreEqual(false, jsonArray4[1]);
            Assert.AreEqual(true, jsonArray4[2]);
            Assert.AreEqual(false, parser.IsLastParseComplete);

            var list = parser.Parse<List<string>>(@"[""abc"",");
            Assert.IsNotNull(list);
            Assert.AreEqual(1, list.Count);
            Assert.AreEqual("abc", list[0]);
            Assert.AreEqual(false, parser.IsLastParseComplete);
        }

        [TestMethod]
        public void Parse_PartialJsonObject()
        {
            var parser = new JSONParser();
            parser.Settings.AllowPartial = true;

            var obj1 = parser.Parse<TestObject>(@"{""A"":");
            Assert.IsNotNull(obj1);
            Assert.AreEqual(0, obj1.A);
            Assert.AreEqual(0, obj1.B);
            Assert.IsNull(obj1.C);
            Assert.AreEqual(false, parser.IsLastParseComplete);

            var obj2 = parser.Parse<TestObject>(@"{""A"":2,");
            Assert.IsNotNull(obj2);
            Assert.AreEqual(2, obj2.A);
            Assert.AreEqual(0, obj2.B);
            Assert.IsNull(obj2.C);
            Assert.AreEqual(false, parser.IsLastParseComplete);

            var obj3 = parser.Parse<TestObject>(@"{""A"":2,""B""");
            Assert.IsNotNull(obj3);
            Assert.AreEqual(2, obj3.A);
            Assert.AreEqual(0, obj3.B);
            Assert.IsNull(obj3.C);
            Assert.AreEqual(false, parser.IsLastParseComplete);

            var obj4 = parser.Parse<TestObject>(@"{""A"":2,""B"":4,""C"":n");
            Assert.IsNotNull(obj4);
            Assert.AreEqual(2, obj4.A);
            Assert.AreEqual(4, obj4.B);
            Assert.IsNull(obj4.C);
            Assert.AreEqual(false, parser.IsLastParseComplete);

            var obj5 = parser.Parse<TestObject>(@"{""A"":2,""B"":4,""C"": {""A"":20,""");
            Assert.IsNotNull(obj5);
            Assert.AreEqual(2, obj5.A);
            Assert.AreEqual(4, obj5.B);
            Assert.IsNotNull(obj5.C);
            Assert.AreEqual(20, obj5.C.A);
            Assert.AreEqual(0, obj5.C.B);
            Assert.IsNull(obj5.C.C);
            Assert.AreEqual(false, parser.IsLastParseComplete);
        }

        [TestMethod]
        public void Parse_PartialJsonObjectName()
        {
            var parser = new JSONParser();
            parser.Settings.AllowPartial = true;

            var obj1 = parser.Parse<TestObject2>(@"{""A");
            Assert.IsNotNull(obj1);
            Assert.AreEqual(0, obj1.ABCDEDFGH);
            Assert.AreEqual(0, obj1.AAAAAAAAA);
            Assert.AreEqual(false, parser.IsLastParseComplete);

            var obj2 = parser.Parse<TestObject2>(@"{""ABCDEDFGH"":12345,""AA");
            Assert.IsNotNull(obj2);
            Assert.AreEqual(12345, obj2.ABCDEDFGH);
            Assert.AreEqual(0, obj2.AAAAAAAAA);
            Assert.AreEqual(false, parser.IsLastParseComplete);
        }

        [TestMethod]
        public void Parse_PartialJsonStringEscape()
        {
            var parser = new JSONParser();
            parser.Settings.AllowPartial = true;

            Assert.AreEqual("啊啊啊", parser.Parse<string>(@"""\u554A\u554A\u554A"""));
            Assert.AreEqual(true, parser.IsLastParseComplete);

            Assert.AreEqual("啊啊啊", parser.Parse<string>(@"""\u554A\u554A\u554A"));
            Assert.AreEqual(false, parser.IsLastParseComplete);

            Assert.AreEqual("啊啊", parser.Parse<string>(@"""\u554A\u554A\u55"));
            Assert.AreEqual(false, parser.IsLastParseComplete);

            Assert.AreEqual("", parser.Parse<string>(@"""\u"));
            Assert.AreEqual(false, parser.IsLastParseComplete);
        }

    }

    public class TestObject2
    {
        public int ABCDEDFGH { get; set; }
        public int AAAAAAAAA { get; set; }
    }
}
