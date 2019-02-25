using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lsj.Util.JSON;

namespace Lsj.Util.Tests.JSON
{
    [TestClass]
    public class SpecifiedTest
    {
        public class TestObject
        {
            public int A { get; set; }
            public int B { get; set; }
            public TestObject C { get; set; }
        }

        [TestMethod]
        public void Specified_Object()
        {
            var obj = new JSONObject();
            var obj2 = new JSONObject();
            obj.Set("A", 1);
            obj.Set("B", 2);
            obj.Set("C", obj2);
            obj2.Set("A", 3);

            var result = obj.SpecifiedTo<TestObject>();
            Assert.AreEqual(1, result.A);
            Assert.AreEqual(2, result.B);
            Assert.AreEqual(3, result.C.A);
            Assert.AreEqual(0, result.C.B);
        }

        [TestMethod]
        public void Specified_Array()
        {
            var array = new JSONArray();
            array.Add(1);
            array.Add(2);

            var result = array.SpecifiedTo<List<int>>();
            Assert.AreEqual(1, result[0]);
            Assert.AreEqual(2, result[1]);
        }
    }
}
