using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Authz;
using static Lsj.Util.Win32.Enums.ACE_TYPE;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// The <see cref="ACCESS_ALLOWED_CALLBACK_ACE"/> structure defines an access control entry (ACE)
    /// for the discretionary access control list (DACL) that controls access to an object.
    /// An access-allowed ACE allows access to an object for a specific trustee identified by a security identifier (SID).
    /// When the <see cref="AuthzAccessCheck"/> function is called,
    /// each <see cref="ACCESS_ALLOWED_CALLBACK_ACE"/> structure contained in the DACL of a <see cref="SECURITY_DESCRIPTOR"/> structure
    /// passed through a pointer to the <see cref="AuthzAccessCheck"/> function invokes a call to the application-defined <see cref="AuthzAccessCheckCallback"/> function,
    /// in which a pointer to the <see cref="ACCESS_ALLOWED_CALLBACK_ACE"/> structure found is passed in the pAce parameter.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winnt/ns-winnt-access_allowed_callback_ace"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// ACE structures must be aligned on DWORD boundaries. All Windows memory-management functions return DWORD-aligned handles to memory.
    /// The access rights specified by the <see cref="Mask"/> member are granted to any trustee that possesses an enabled SID
    /// that matches the SID stored in the <see cref="SidStart"/> member.
    /// When an <see cref="ACCESS_ALLOWED_CALLBACK_ACE"/> structure is created,
    /// sufficient memory must be allocated to accommodate the complete SID of the trustee in the <see cref="SidStart"/> member and the contiguous memory that follows it.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct ACCESS_ALLOWED_CALLBACK_ACE
    {
        /// <summary>
        /// <see cref="ACE_HEADER"/> structure that specifies the size and type of ACE.
        /// It also contains flags that control inheritance of the ACE by child objects.
        /// The <see cref="ACE_HEADER.AceType"/> member of the <see cref="ACE_HEADER"/> structure should be set to <see cref="ACCESS_ALLOWED_CALLBACK_ACE_TYPE"/>,
        /// and the <see cref="ACE_HEADER.AceSize"/> member should be set to the total number of bytes allocated for the <see cref="ACCESS_ALLOWED_CALLBACK_ACE"/> structure.
        /// </summary>
        public ACE_HEADER Header;

        /// <summary>
        /// Specifies an <see cref="ACCESS_MASK"/> structure that specifies the access rights granted by this ACE.
        /// </summary>
        public ACCESS_MASK Mask;

        /// <summary>
        /// The first DWORD of a trustee's SID.
        /// </summary>
        public DWORD SidStart;
    }
}
