using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;

namespace Lsj.Util.AspNetCore.PagedList
{
    /// <summary>
    /// PagedList
    /// </summary>
    public interface IPagedList
    {
        /// <summary>
        /// Total Item Count of Source List
        /// </summary>
        int TotalItemCount { get; }

        /// <summary>
        /// Page Count Of Source List
        /// </summary>
        int PageCount { get; }

        /// <summary>
        /// If Has Previous Page
        /// </summary>
        bool HasPrevious { get; }

        /// <summary>
        /// If Has Next Page
        /// </summary>
        bool HasNext { get; }

        /// <summary>
        /// PageNumber
        /// </summary>
        int PageNumber { get; }
    }

    /// <summary>
    /// PagedList
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IPagedList<out T> : IEnumerable<T>, IReadOnlyList<T>, IPagedList
    {
        
    }
}
