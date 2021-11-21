using Lsj.Util.IO;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lsj.Util.Tests.IO
{
    [TestClass]
    public class BufferListStreamTests
    {
        [TestMethod]
        public void TestReadWrite()
        {
            var stream = new BufferListStream();
            var buffer1 = new byte[] { 0, 1, 2, 3, 5 };
            stream.AddBuffer(buffer1);
            buffer1[4] = 4;
            var buffer2 = new byte[] { 0, 1, 2, 3, 4, 5, 6, 7, 8, 9, 10 };
            stream.Write(buffer2, 5, 5);
            buffer2[5] = 6;

            int val = 0;
            var readBuffer = new byte[5];
            Assert.AreEqual(5, stream.Read(readBuffer));
            for (int i = 0; i < 5; i++, val++)
            {
                Assert.AreEqual(val, readBuffer[i]);
            }
            readBuffer = new byte[0];
            Assert.AreEqual(0, stream.Read(readBuffer));
            readBuffer = new byte[10];
            Assert.AreEqual(5, stream.Read(readBuffer));
            for (int i = 0; i < 5; i++, val++)
            {
                Assert.AreEqual(val, readBuffer[i]);
            }
            Assert.AreEqual(0, stream.Read(readBuffer));
        }
    }
}
