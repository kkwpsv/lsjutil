using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOLEAN;
using static Lsj.Util.Win32.Enums.IoControlCodes;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Specifies the sparse state to be set.
    /// Windows Server 2003 and Windows XP:  This structure is optional. For more information, see <see cref="FSCTL_SET_SPARSE"/>.
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct FILE_SET_SPARSE_BUFFER
    {
        /// <summary>
        /// If <see cref="TRUE"/>, makes the file sparse.
        /// If <see cref="FALSE"/>, makes the file not sparse.
        /// Windows Server 2008 R2, Windows 7, Windows Server 2008 and Windows Vista:
        /// A value of <see cref="FALSE"/> for this member is valid only on files that no longer have any sparse regions.
        /// For more information, see <see cref="FSCTL_SET_SPARSE"/>.
        /// Windows Server 2003 and Windows XP:
        /// A value of <see cref="FALSE"/> for this member is not supported.
        /// Specifying <see cref="FALSE"/> will cause the <see cref="FSCTL_SET_SPARSE"/> call to fail.
        /// </summary>
        public BOOLEAN SetSparse;
    }
}
