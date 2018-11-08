using Lsj.Util.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;

namespace Lsj.Util.Tests.Collections
{
    [TestClass]
    public class PriorityQueueTest
    {
        [TestMethod]
        public void TestPriorityQueue()
        {
            var q = new PriorityQueue<int>();
            for (int i = 10; i < 20; i++)
            {
                q.Enqueue(i);
            }
            for (int i = 0; i < 10; i++)
            {
                q.Enqueue(i);
            }
            for (int j = 19; j >= 0; j--)
            {
                Assert.AreEqual(j, q.Dequeue());
            }
            Assert.ThrowsException<InvalidOperationException>(() => q.Dequeue());
        }
    }
}
