using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Advapi32;
using static Lsj.Util.Win32.Enums.ACE_TYPE;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// The <see cref="ACCESS_DENIED_ACE"/> structure defines an access control entry (ACE)
    /// for the discretionary access control list (DACL) that controls access to an object.
    /// An access-denied ACE denies access to an object for a specific trustee identified by a security identifier (SID).
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winnt/ns-winnt-access_denied_ace"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// ACE structures must be aligned on DWORD boundaries.
    /// All Windows memory-management functions return DWORD-aligned handles to memory.
    /// The access rights specified by the <see cref="Mask"/> member are granted to any trustee
    /// that possesses an enabled SID that matches the SID stored in the <see cref="SidStart"/> member.
    /// An <see cref="ACCESS_DENIED_ACE"/> structure can be created in an access control list (ACL)
    /// by a call to the <see cref="AddAccessDeniedAce"/> or <see cref="AddAccessDeniedAceEx"/> function.
    /// When these functions are used, the correct amount of memory needed to accommodate the trustee's SID is allocated
    /// and the values of the <code>Header.AceType</code> and <code>Header.AceSize</code> members are set automatically.
    /// If the <see cref="AddAccessDeniedAceEx"/> function is used, the <code>Header.AceFlags</code> member is also set.
    /// When an <see cref="ACCESS_DENIED_ACE"/> structure is created outside an ACL,
    /// sufficient memory must be allocated to accommodate the complete SID of the trustee in the <see cref="SidStart"/> member and the contiguous memory following it,
    /// and the values of the <code>Header.AceType</code>, <code>Header.AceFlags</code>, and <code>Header.AceSize</code> members must be set explicitly by the application.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct ACCESS_DENIED_ACE
    {
        /// <summary>
        /// <see cref="ACE_HEADER"/> structure that specifies the size and type of ACE.
        /// It also contains flags that control inheritance of the ACE by child objects.
        /// The <see cref="ACE_HEADER.AceType"/> member of the <see cref="ACE_HEADER"/> structure should be set to <see cref="ACCESS_DENIED_ACE_TYPE"/>,
        /// and the <see cref="ACE_HEADER.AceSize"/> member should be set to the total number of bytes allocated for the <see cref="ACCESS_DENIED_ACE"/> structure.
        /// </summary>
        public ACE_HEADER Header;

        /// <summary>
        /// Specifies an <see cref="ACCESS_MASK"/> structure that specifies the access rights granted by this ACE.
        /// </summary>
        public ACCESS_MASK Mask;

        /// <summary>
        /// The first DWORD of a trustee's SID.
        /// The remaining bytes of the SID are stored in contiguous memory after the <see cref="SidStart"/> member.
        /// This SID can be appended with application data.
        /// </summary>
        public DWORD SidStart;
    }
}
