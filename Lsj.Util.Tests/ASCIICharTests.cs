using Microsoft.VisualStudio.TestTools.UnitTesting;
using Lsj.Util;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lsj.Util.Tests
{
    [TestClass()]
    public class ASCIICharTests
    {
        [TestMethod()]
        public void IsNumberTest_Number()
        {
            Assert.AreEqual(ASCIIChar.IsNumber((byte)'0'), true);
        }
        [TestMethod()]
        public void IsNumberTest_NotNumber()
        {
            Assert.AreEqual(ASCIIChar.IsNumber((byte)'A'), false);
        }
    }
}