using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.ComInterfaces;

namespace Lsj.Util.Win32.Extensions.COM
{
    /// <summary>
    /// COM Object Creators
    /// </summary>
    public static class COMObjectCreators
    {
        /// <summary>
        /// NetworkListManager
        /// </summary>
        public static P<INetworkListManager> NetworkListManager => COMExtensions.CreateInstance<INetworkListManager>(CLSIDs.CLSID_NetworkListManager, IIDs.IID_INetworkListManager);
    }
}
