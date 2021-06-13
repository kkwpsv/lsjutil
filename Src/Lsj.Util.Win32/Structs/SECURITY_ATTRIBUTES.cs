using Lsj.Util.Win32.BaseTypes;
using System;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Advapi32;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// The <see cref="SECURITY_ATTRIBUTES"/> structure contains the security descriptor for an object and
    /// specifies whether the handle retrieved by specifying this structure is inheritable.
    /// This structure provides security settings for objects created by various functions,
    /// such as <see cref="CreateFile"/>, <see cref="CreatePipe"/>, <see cref="CreateProcess"/>,
    /// <see cref="RegCreateKeyEx"/>, or <see cref="RegSaveKeyEx"/>.
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/previous-versions/windows/desktop/legacy/aa379560(v%3Dvs.85)"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct SECURITY_ATTRIBUTES
    {
        /// <summary>
        /// The size, in bytes, of this structure. Set this value to the size of the <see cref="SECURITY_ATTRIBUTES"/> structure.
        /// </summary>
        public DWORD nLength;

        /// <summary>
        /// A pointer to a <see cref="SECURITY_DESCRIPTOR"/> structure that controls access to the object.
        /// If the value of this member is <see cref="IntPtr.Zero"/>, the object is assigned the default security descriptor
        /// associated with the access token of the calling process.
        /// This is not the same as granting access to everyone by assigning a <see cref="IntPtr.Zero"/> discretionary access control list (DACL).
        /// By default, the default DACL in the access token of a process allows access only to the user represented by the access token.
        /// For information about creating a security descriptor, see Creating a Security Descriptor.
        /// </summary>
        public LPVOID lpSecurityDescriptor;

        /// <summary>
        /// A <see cref="BOOL"/> value that specifies whether the returned handle is inherited when a new process is created.
        /// If this member is <see cref="TRUE"/>, the new process inherits the handle.
        /// </summary>
        public BOOL bInheritHandle;
    }
}
