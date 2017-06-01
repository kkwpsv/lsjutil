#if NETCOREAPP1_1
using Lsj.Util.Core.Net.Web.Event;
#else
using Lsj.Util.Net.Web.Event;
#endif

#if NETCOREAPP1_1
namespace Lsj.Util.Core.Net.Web.Interfaces
#else
namespace Lsj.Util.Net.Web.Interfaces
#endif
{
    /// <summary>
    /// 
    /// </summary>
    public interface IModule
    {
        /// <summary>
        /// Process
        /// </summary>
        /// <param name="website"></param>
        /// <param name="args"></param>
        void Process(object website, ProcessEventArgs args);
    }
}
