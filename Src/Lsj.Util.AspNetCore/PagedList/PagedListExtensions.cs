using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace Lsj.Util.AspNetCore.PagedList
{
    /// <summary>
    /// PagedList Extension Methods
    /// </summary>
    public static class PagedListExtensions
    {
        /// <summary>
        /// Create a PagedList
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="srcSet">source set</param>
        /// <param name="pageNum">page number</param>
        /// <param name="pageSize">page size </param>
        /// <returns>PagedList</returns>
        public static IPagedList<T> ToPagedList<T>(this IEnumerable<T> srcSet, int pageNum, int pageSize)
        {
            return new PagedList<T>(srcSet, pageNum, pageSize);
        }

        /// <summary>
        /// Create a PagedList
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="srcSet">source set</param>
        /// <param name="pageNum">page number</param>
        /// <param name="pageSize">page size </param>
        /// <returns>PagedList</returns>
        public static IPagedList<T> ToPagedList<T>(this IQueryable<T> srcSet, int pageNum, int pageSize)
        {
            return new PagedList<T>(srcSet, pageNum, pageSize);
        }
    }
}
