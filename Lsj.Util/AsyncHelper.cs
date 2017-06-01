using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

#if NETCOREAPP1_1
namespace Lsj.Util.Core
#else
namespace Lsj.Util
#endif
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
