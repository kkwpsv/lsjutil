using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Lsj.Util.AspNetCore.PagedList;


namespace Lsj.Util.Tests.AspNetCore.PagedList
{
    [TestClass]
    public class PagedListTest
    {
        [TestMethod]
        public void PagedList_ErrorAgument()
        {
            Assert.ThrowsException<ArgumentNullException>(() => { ((IEnumerable<object>)null).ToPagedList(1, 1); });
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => { new int[] { 1 }.ToPagedList(0, 1); });
            Assert.ThrowsException<ArgumentOutOfRangeException>(() => { new int[] { 1 }.ToPagedList(1, 0); });
        }
        [TestMethod]
        public void PagedList_Normal()
        {
            var list = new List<int> {  1, 2,
                                        3, 4,
                                        5, 6,
                                        7, 8,
                                        9 };
            var pagedList = list.ToPagedList(3, 2);
            Assert.AreEqual(9, pagedList.TotalItemCount);
            Assert.AreEqual(5, pagedList.PageCount);
            Assert.AreEqual(true, pagedList.HasPrevious);
            Assert.AreEqual(true, pagedList.HasNext);
            Assert.AreEqual(2, pagedList.Count);
            Assert.AreEqual(5, pagedList[0]);

            pagedList = list.ToPagedList(1, 2);
            Assert.AreEqual(9, pagedList.TotalItemCount);
            Assert.AreEqual(5, pagedList.PageCount);
            Assert.AreEqual(false, pagedList.HasPrevious);
            Assert.AreEqual(true, pagedList.HasNext);
            Assert.AreEqual(2, pagedList.Count);
            Assert.AreEqual(1, pagedList[0]);

            pagedList = list.ToPagedList(5, 2);
            Assert.AreEqual(9, pagedList.TotalItemCount);
            Assert.AreEqual(5, pagedList.PageCount);
            Assert.AreEqual(true, pagedList.HasPrevious);
            Assert.AreEqual(false, pagedList.HasNext);
            Assert.AreEqual(1, pagedList.Count);
            Assert.AreEqual(9, pagedList[0]);
        }
    }
}
