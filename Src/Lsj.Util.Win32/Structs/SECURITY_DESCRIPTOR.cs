using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// The <see cref="SECURITY_DESCRIPTOR"/> structure contains the security information associated with an object.
    /// Applications use this structure to set and query an object's security status.
    /// Because the internal format of a security descriptor can vary,
    /// we recommend that applications not modify the <see cref="SECURITY_DESCRIPTOR"/> structure directly.
    /// For creating and manipulating a security descriptor, use the functions listed in See Also.
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/winnt/ns-winnt-security_descriptor
    /// </para>
    /// </summary>
    /// <remarks>
    /// A security descriptor includes information that specifies the following components of an object's security:
    /// An owner security identifier (SID)
    /// A primary group SID
    /// A discretionary access control list (DACL)
    /// A system access control list (SACL)
    /// Qualifiers for the preceding items
    /// Several functions that use the <see cref="SECURITY_DESCRIPTOR"/> structure require
    /// that this structure be aligned on a valid pointer boundary in memory.
    /// These boundaries vary depending on the type of processor used.
    /// Memory allocation functions such as malloc and <see cref="LocalAlloc"/> return properly aligned pointers.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct SECURITY_DESCRIPTOR
    {
        /// <summary>
        /// 
        /// </summary>
        public BYTE Revision;

        /// <summary>
        /// 
        /// </summary>
        public BYTE Sbz1;

        /// <summary>
        /// 
        /// </summary>
        public SECURITY_DESCRIPTOR_CONTROL Control;

        /// <summary>
        /// 
        /// </summary>
        public PSID Owner;

        /// <summary>
        /// 
        /// </summary>
        public PSID Group;

        /// <summary>
        /// 
        /// </summary>
        public IntPtr Sacl;

        /// <summary>
        /// 
        /// </summary>
        public IntPtr Dacl;
    }
}
