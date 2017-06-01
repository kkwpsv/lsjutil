using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Lsj.Util
{
#if NETCOREAPP1_1
    public static class AsyncHelper
    {
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
