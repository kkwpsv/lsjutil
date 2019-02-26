using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lsj.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lsj.Util.Tests
{
    [TestClass]
    public class ASCIICharTests
    {
        [TestMethod]
        public void IsNumberTest()
        {
            Assert.AreEqual(ASCIIChar.IsNumber((byte)'0'), true);
            Assert.AreEqual(ASCIIChar.IsNumber(20), false);
            Assert.AreEqual(ASCIIChar.IsNumber(60), false);
        }
    }
}