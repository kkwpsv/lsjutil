using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Enums;
using System.ComponentModel;
using System.IO;
using static Lsj.Util.Win32.Kernel32;
using static Lsj.Util.Win32.UnsafePInvokeExtensions;
using static Lsj.Util.Win32.Enums.IoControlCodes;
using Lsj.Util.Win32.Structs;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Constants;

namespace Lsj.Util.Win32.Extensions
{
    /// <summary>
    /// Sparse File Extensions
    /// </summary>
    public static class SparseFileExtensions
    {
        /// <summary>
        /// Is Support Sparse File
        /// </summary>
        /// <param name="path">
        /// The root directory of the volume to be described.
        /// If this parameter is <see langword="null"/>, the root of the current directory is used.
        /// A trailing backslash is required.
        /// For example, you specify \MyServer\MyShare as "\MyServer\MyShare\", or the C drive as "C:\".
        /// </param>
        /// <returns></returns>
        public static bool IsSupportSparseFile(string path)
        {
            var result = GetVolumeInformation("C:\\", null, 0, out NullRef<DWORD>(), out NullRef<DWORD>(), out var fileSystemFlags, null, 0);
            if (result)
            {
                return (fileSystemFlags & FileSystemFlags.FILE_SUPPORTS_SPARSE_FILES) != 0;
            }
            else
            {
                throw new Win32Exception();
            }
        }

        /// <summary>
        /// Set As Sparse File
        /// </summary>
        /// <param name="file"></param>
        /// <param name="isSparseFile"></param>
        /// <returns>
        /// Is succeeds.
        /// To get extended error information, call<see cref="GetLastError"/>.
        /// </returns>
        public static bool SetAsSparseFile(FileStream file, bool isSparseFile)
        {
#if NET40 || NET45
            var size = Marshal.SizeOf(typeof(FILE_SET_SPARSE_BUFFER));

#else
            var size = Marshal.SizeOf<FILE_SET_SPARSE_BUFFER>();
#endif
            var FILE_SET_SPARSE_BUFFER = new FILE_SET_SPARSE_BUFFER
            {
                SetSparse = isSparseFile
            };

            var result = DeviceIoControl(file.SafeFileHandle.DangerousGetHandle(), FSCTL_SET_SPARSE, AsPointer(ref FILE_SET_SPARSE_BUFFER),
                size, NULL, 0, out _, NullRef<OVERLAPPED>());

            return result;
        }
    }
}
