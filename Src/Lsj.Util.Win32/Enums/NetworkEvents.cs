namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Network Events
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winsock2/nf-winsock2-wsaeventselect
    /// </para>
    /// </summary>
    public enum NetworkEvents : uint
    {
        /// <summary>
        /// FD_READ
        /// </summary>
        FD_READ = 0x01,

        /// <summary>
        /// FD_WRITE
        /// </summary>
        FD_WRITE = 0x02,

        /// <summary>
        /// FD_OOB
        /// </summary>
        FD_OOB = 0x04,

        /// <summary>
        /// FD_ACCEPT
        /// </summary>
        FD_ACCEPT = 0x08,

        /// <summary>
        /// FD_CONNECT
        /// </summary>
        FD_CONNECT = 0x10,

        /// <summary>
        /// FD_CLOSE
        /// </summary>
        FD_CLOSE = 0x20,

        /// <summary>
        /// FD_QOS
        /// </summary>
        FD_QOS = 0x40,

        /// <summary>
        /// FD_GROUP_QOS
        /// </summary>
        FD_GROUP_QOS = 0x80,

        /// <summary>
        /// FD_ROUTING_INTERFACE_CHANGE
        /// </summary>
        FD_ROUTING_INTERFACE_CHANGE = 0x100,

        /// <summary>
        /// FD_ADDRESS_LIST_CHANGE
        /// </summary>
        FD_ADDRESS_LIST_CHANGE = 0x200,
    }
}
