using Lsj.Util.Collections;
using Microsoft.VisualStudio.TestTools.UnitTesting;

namespace Lsj.Util.Tests.Collections
{
    [TestClass]
    public class WeightedSimpleDiagraphTest
    {
        [TestMethod]
        public void TestDijkstra()
        {
            var g = new WeightedSimpleDigraph(6);
            g.AddEdge(1, 5, 12);
            g.AddEdge(5, 1, 8);
            g.AddEdge(1, 2, 16);
            g.AddEdge(2, 1, 29);
            g.AddEdge(5, 2, 32);
            g.AddEdge(2, 4, 13);
            g.AddEdge(4, 2, 27);
            g.AddEdge(1, 3, 15);
            g.AddEdge(3, 1, 21);
            g.AddEdge(3, 4, 7);
            g.AddEdge(4, 3, 19);

            g.OptimalPathWithDijkstra(5, out int?[] dis, out int?[] prv);

            Assert.AreEqual(6, dis.Length);
            Assert.AreEqual(6, prv.Length);
            Assert.AreEqual(null, dis[0]);
            Assert.AreEqual(8, dis[1]);
            Assert.AreEqual(24, dis[2]);
            Assert.AreEqual(23, dis[3]);
            Assert.AreEqual(30, dis[4]);
            Assert.AreEqual(0, dis[5]);
            Assert.AreEqual(null, prv[0]);
            Assert.AreEqual(5, prv[1]);
            Assert.AreEqual(1, prv[2]);
            Assert.AreEqual(1, prv[3]);
            Assert.AreEqual(3, prv[4]);
            Assert.AreEqual(5, prv[5]);
        }
    }
}
