using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lsj.Util.AspNetCore.PagedList
{
    internal class PagedList<T> : IPagedList<T>
    {
        public PagedList(IEnumerable<T> srcSet, int pageNum, int pageSize) : this(srcSet.AsQueryable(), pageNum, pageSize)
        {

        }
        public PagedList(IQueryable<T> srcSet, int pageNum, int pageSize)
        {
            if (srcSet == null)
            {
                throw new ArgumentNullException("internalSet", "Internal Set cannot be null");
            }
            if (pageNum < 1)
            {
                throw new ArgumentOutOfRangeException("pageNum", pageNum, "Page Number must be bigger than 1.");
            }
            if (pageSize < 1)
            {
                throw new ArgumentOutOfRangeException("pageSize", pageSize, "Page Sieze must be bigger than 1.");
            }
            this.PageNumber = pageNum;
            this.TotalItemCount = srcSet.Count();
            this.PageCount = (TotalItemCount / pageSize) + (TotalItemCount % pageSize == 0 ? 0 : 1);
            this.HasPrevious = PageNumber != 1;
            this.HasNext = PageNumber < PageCount;
            this.SubList = srcSet.Skip((PageNumber - 1) * pageSize).Take(pageSize).ToList();
        }

        private readonly List<T> SubList;


        public int TotalItemCount { get; }
        public int PageCount { get; }
        public bool HasPrevious { get; }
        public bool HasNext { get; }
        public int PageNumber { get; }

        public int Count => SubList.Count();

        public T this[int index] => SubList[index];

        public IEnumerator<T> GetEnumerator() => SubList.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
