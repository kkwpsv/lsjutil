using Lsj.Util.Net.Web.Event;

namespace Lsj.Util.Net.Web.Interfaces
{
    /// <summary>
    /// Module
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
