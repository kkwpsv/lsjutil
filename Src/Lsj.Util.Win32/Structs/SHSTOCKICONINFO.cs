using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.Marshals.ByValStringStructs;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Enums.SHGetStockIconInfoFlags;
using static Lsj.Util.Win32.Shell32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Receives information used to retrieve a stock Shell icon.
    /// This structure is used in a call <see cref="SHGetStockIconInfo"/>.
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/shellapi/ns-shellapi-shstockiconinfo"/>
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct SHSTOCKICONINFO
    {
        /// <summary>
        /// The size of this structure, in bytes.
        /// </summary>
        public DWORD cbSize;

        /// <summary>
        /// When <see cref="SHGetStockIconInfo"/> is called with the <see cref="SHGSI_ICON"/> flag, this member receives a handle to the icon.
        /// </summary>
        public HICON hIcon;

        /// <summary>
        /// When <see cref="SHGetStockIconInfo"/> is called with the <see cref="SHGSI_SYSICONINDEX"/> flag,
        /// this member receives the index of the image in the system icon cache.
        /// </summary>
        public int iSysImageIndex;

        /// <summary>
        /// When <see cref="SHGetStockIconInfo"/> is called with the <see cref="SHGSI_ICONLOCATION"/> flag,
        /// this member receives the index of the icon in the resource whose path is received in <see cref="szPath"/>.
        /// </summary>
        public int iIcon;

        /// <summary>
        /// When <see cref="SHGetStockIconInfo"/> is called with the <see cref="SHGSI_ICONLOCATION"/> flag,
        /// this member receives the path of the resource that contains the icon.
        /// The index of the icon within the resource is received in iIcon.
        /// </summary>
        public ByValStringStructForSizeMAX_PATH szPath;
    }
}
