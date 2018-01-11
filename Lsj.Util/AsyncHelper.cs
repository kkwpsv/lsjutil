using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Lsj.Util
{
#if NETCOREAPP1_1
    /// <summary>
    /// Async Helper
    /// </summary>
    public static class AsyncHelper
    {
        /// <summary>
        /// Wait and Get the Result
        /// </summary>
        /// <typeparam name="T"></typeparam>
        /// <param name="task"></param>
        /// <returns></returns>
        public static T WaitAndGetResult<T>(this Task<T> task)
        {
            var waiter = task.GetAwaiter();
            var result = default(T);
            waiter.OnCompleted(() => { result = waiter.GetResult(); });
            return result;
        }
    }
#endif
}
