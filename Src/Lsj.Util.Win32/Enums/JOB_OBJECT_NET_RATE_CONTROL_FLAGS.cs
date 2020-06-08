using Lsj.Util.Win32.Structs;
using System;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// Specifies types of scheduling policies for network rate control.
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winnt/ne-winnt-job_object_net_rate_control_flags
    /// </para>
    /// </summary>
    [Flags]
    public enum JOB_OBJECT_NET_RATE_CONTROL_FLAGS
    {
        /// <summary>
        /// Turns on the control of the network traffic.
        /// You must set this value if you also set either <see cref="JOB_OBJECT_NET_RATE_CONTROL_MAX_BANDWIDTH"/>
        /// or <see cref="JOB_OBJECT_NET_RATE_CONTROL_DSCP_TAG"/>.
        /// </summary>
        JOB_OBJECT_NET_RATE_CONTROL_ENABLE = 0x1,

        /// <summary>
        /// 
        /// </summary>
        JOB_OBJECT_NET_RATE_CONTROL_MAX_BANDWIDTH = 0x2,

        /// <summary>
        /// Sets the DSCP field in the packet header to the value of the <see cref="JOBOBJECT_NET_RATE_CONTROL_INFORMATION.DscpTag"/> member
        /// of the <see cref="JOBOBJECT_NET_RATE_CONTROL_INFORMATION"/> structure.
        /// For information about DSCP, see Differentiated Services.
        /// </summary>
        JOB_OBJECT_NET_RATE_CONTROL_DSCP_TAG = 0x4,

        /// <summary>
        /// The combination of all of the valid flags for the <see cref="JOB_OBJECT_NET_RATE_CONTROL_FLAGS"/> enumeration.
        /// </summary>
        JOB_OBJECT_NET_RATE_CONTROL_VALID_FLAGS = 0x7
    }
}
