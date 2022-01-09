using Lsj.Util.Win32.BaseTypes;
using Lsj.Util.Win32.ComInterfaces;
using Lsj.Util.Win32.Marshals.ByValStructs;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Shell32;
using static Lsj.Util.Win32.User32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains information about a file object.k
    /// </para>
    /// <para>
    /// From: <see href="https://docs.microsoft.com/zh-cn/windows/win32/api/shellapi/ns-shellapi-shfileinfow"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// This structure is used with the <see cref="SHGetFileInfo"/> function.
    /// The shellapi.h header defines <see cref="SHFILEINFO"/> as an alias which automatically selects
    /// the ANSI or Unicode version of this function based on the definition of the UNICODE preprocessor constant.
    /// Mixing usage of the encoding-neutral alias with code that not encoding-neutral can lead to
    /// mismatches that result in compilation or runtime errors.
    /// For more information, see Conventions for Function Prototypes.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct SHFILEINFO
    {
        /// <summary>
        /// A handle to the icon that represents the file.
        /// You are responsible for destroying this handle with <see cref="DestroyIcon"/> when you no longer need it.
        /// </summary>
        public HICON hIcon;

        /// <summary>
        /// The index of the icon image within the system image list.
        /// </summary>
        public int iIcon;

        /// <summary>
        /// An array of values that indicates the attributes of the file object.
        /// For information about these values, see the <see cref="IShellFolder.GetAttributesOf"/> method.
        /// </summary>
        public DWORD dwAttributes;

        /// <summary>
        /// A string that contains the name of the file as it appears in the Windows Shell,
        /// or the path and file name of the file that contains the icon representing the file.
        /// </summary>
        public ByValStringStructForSizeMAX_PATH szDisplayName;

        /// <summary>
        /// A string that describes the type of file.
        /// </summary>
        public ByValStringStructForSize80 szTypeName;
    }
}
