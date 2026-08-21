using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains information about a pagefile.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/psapi/ns-psapi-enum_page_file_information"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct ENUM_PAGE_FILE_INFORMATION
    {
        /// <summary>
        /// The size of this structure, in bytes.
        /// </summary>
        public DWORD cb;

        /// <summary>
        /// This member is reserved.
        /// </summary>
        public DWORD Reserved;

        /// <summary>
        /// The total size of the pagefile, in pages.
        /// </summary>
        public SIZE_T TotalSize;

        /// <summary>
        /// The current pagefile usage, in pages.
        /// </summary>
        public SIZE_T TotalInUse;

        /// <summary>
        /// The peak pagefile usage, in pages.
        /// </summary>
        public SIZE_T PeakUsage;
    }
}
