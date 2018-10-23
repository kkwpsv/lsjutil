using Lsj.Util.Reflection;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System.Collections;
using System.Collections.Generic;

namespace Lsj.Util.Tests.Reflection
{
    [TestClass]
    public class ReflectionHelperTest
    {
        [TestMethod]
        public void IsDictionary()
        {
            Assert.AreEqual(false, new object().IsDictionary());
            Assert.AreEqual(false, typeof(object).IsDictionary());
            Assert.AreEqual(true, typeof(Hashtable).IsDictionary());
            Assert.AreEqual(true, typeof(Dictionary<,>).IsDictionary());
        }
    }
}
