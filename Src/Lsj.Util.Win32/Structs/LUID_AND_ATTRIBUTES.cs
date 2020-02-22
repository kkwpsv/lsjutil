using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// <see cref="LUID_AND_ATTRIBUTES"/> represents a locally unique identifier (LUID) and its attributes.
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows-hardware/drivers/ddi/wdm/ns-wdm-_luid_and_attributes
    /// </para>
    /// </summary>
    /// <remarks>
    /// An <see cref="LUID_AND_ATTRIBUTES"/> structure can represent an <see cref="LUID"/> whose attributes change frequently,
    /// such as when it is used to represent privileges in the <see cref="PRIVILEGE_SET"/> structure.
    /// Privileges are represented by LUIDs and have attributes indicating whether they are currently enabled or disabled.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct LUID_AND_ATTRIBUTES
    {
        /// <summary>
        /// An LUID value.
        /// </summary>
        public LUID Luid;

        /// <summary>
        /// Specifies attributes of the LUID.
        /// This value contains up to 32 one-bit flags. Its meaning depends on the definition and use of the LUID.
        /// </summary>
        public uint Attributes;
    }
}
