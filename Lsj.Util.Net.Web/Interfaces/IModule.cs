using System;
using Lsj.Util.Net.Web.Event;
using Lsj.Util.Net.Web.Interfaces;

namespace Lsj.Util.Net.Web.Interfaces
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
