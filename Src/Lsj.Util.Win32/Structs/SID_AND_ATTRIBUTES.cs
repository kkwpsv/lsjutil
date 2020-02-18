using System;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// The <see cref="SID_AND_ATTRIBUTES"/> structure represents a security identifier (SID) and its attributes.
    /// SIDs are used to uniquely identify users or groups.
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winnt/ns-winnt-sid_and_attributes
    /// </para>
    /// </summary>
    /// <remarks>
    /// A group is represented by a SID.
    /// SIDs have attributes that indicate whether they are currently enabled, disabled, or mandatory.
    /// SIDs also indicate how these attributes are used.
    /// A <see cref="SID_AND_ATTRIBUTES"/> structure can represent a SID whose attributes change frequently.
    /// For example, <see cref="SID_AND_ATTRIBUTES"/> is used to represent groups in the <see cref="TOKEN_GROUPS"/> structure.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct SID_AND_ATTRIBUTES
    {
        /// <summary>
        /// A pointer to a SID structure.
        /// </summary>
        public IntPtr Sid;

        /// <summary>
        /// Specifies attributes of the SID.
        /// This value contains up to 32 one-bit flags. Its meaning depends on the definition and use of the SID.
        /// </summary>
        public uint Attributes;
    }
}
