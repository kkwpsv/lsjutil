using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Callbacks;
using Lsj.Util.Win32.Enums;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.BaseTypes.BOOL;
using static Lsj.Util.Win32.Constants;
using static Lsj.Util.Win32.Enums.CopyFileFlags;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains extended parameters for the <see cref="CopyFile2"/> function.
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/winbase/ns-winbase-copyfile2_extended_parameters"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct COPYFILE2_EXTENDED_PARAMETERS
    {
        /// <summary>
        /// Contains the size of this structure, <code>sizeof(COPYFILE2_EXTENDED_PARAMETERS)</code>.
        /// </summary>
        public DWORD dwSize;

        /// <summary>
        /// Contains a combination of zero or more of these flag values.
        /// <see cref="COPY_FILE_ALLOW_DECRYPTED_DESTINATION"/>, <see cref="COPY_FILE_COPY_SYMLINK"/>, <see cref="COPY_FILE_FAIL_IF_EXISTS"/>
        /// <see cref="COPY_FILE_NO_BUFFERING"/>, <see cref="COPY_FILE_NO_OFFLOAD"/>, <see cref="COPY_FILE_OPEN_SOURCE_FOR_WRITE"/>,
        /// <see cref="COPY_FILE_RESTARTABLE"/>, <see cref="COPY_FILE_REQUEST_SECURITY_PRIVILEGES"/>, <see cref="COPY_FILE_RESUME_FROM_PAUSE"/>
        /// </summary>
        public CopyFileFlags dwCopyFlags;

        /// <summary>
        /// If this flag is set to <see cref="TRUE"/> during the copy operation then the copy operation is canceled.
        /// </summary>
        public P<BOOL> pfCancel;

        /// <summary>
        /// The optional address of a callback function of type <see cref="PCOPYFILE2_PROGRESS_ROUTINE"/>
        /// that is called each time another portion of the file has been copied.
        /// This parameter can be <see cref="NULL"/>.
        /// For more information on the progress callback function, see the CopyFile2ProgressRoutine callback function.
        /// </summary>
        public PCOPYFILE2_PROGRESS_ROUTINE pProgressRoutine;

        /// <summary>
        /// A pointer to application-specific context information to be passed to the CopyFile2ProgressRoutine.
        /// </summary>
        public PVOID pvCallbackContext;
    }
}
