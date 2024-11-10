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
                throw new ArgumentOutOfRangeException("pageSize", pageSize, "Page Size must be bigger than 1.");
            }
            PageNumber = pageNum;
            TotalItemCount = srcSet.Count();
            PageCount = (TotalItemCount / pageSize) + (TotalItemCount % pageSize == 0 ? 0 : 1);
            HasPrevious = PageNumber != 1;
            HasNext = PageNumber < PageCount;
            _subList = srcSet.Skip((PageNumber - 1) * pageSize).Take(pageSize).ToList();
        }

        private readonly List<T> _subList;


        public int TotalItemCount { get; }
        public int PageCount { get; }
        public bool HasPrevious { get; }
        public bool HasNext { get; }
        public int PageNumber { get; }

        public int Count => _subList.Count();

        public T this[int index] => _subList[index];

        public IEnumerator<T> GetEnumerator() => _subList.GetEnumerator();
        IEnumerator IEnumerable.GetEnumerator() => GetEnumerator();
    }
}
