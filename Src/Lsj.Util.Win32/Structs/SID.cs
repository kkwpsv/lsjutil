using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Constants;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// The security identifier (SID) structure is a variable-length structure used to uniquely identify users or groups.
    /// Applications should not modify a SID directly.
    /// To create and manipulate a security identifier, use the functions listed in the See Also section.
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winnt/ns-winnt-sid"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct SID
    {
        /// <summary>
        /// 
        /// </summary>
        public BYTE Revision;

        /// <summary>
        /// 
        /// </summary>
        public BYTE SubAuthorityCount;

        /// <summary>
        /// 
        /// </summary>
        public SID_IDENTIFIER_AUTHORITY IdentifierAuthority;

        /// <summary>
        /// 
        /// </summary>
        public DWORD SubAuthority;
    }
}
