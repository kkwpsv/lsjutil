using Lsj.Util.Win32.Enums;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// Contains operating system version information.
    /// The information includes major and minor version numbers, a build number, a platform identifier,
    /// and information about product suites and the latest Service Pack installed on the system.
    /// This structure is used with the <see cref="GetVersionEx"/> and <see cref="VerifyVersionInfo"/> functions.
    /// </para>
    /// </summary>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct OSVERSIONINFOEX
    {
        /// <summary>
        /// The size of this data structure, in bytes. Set this member to sizeof(<see cref="OSVERSIONINFOEX"/>).
        /// </summary>
        public uint dwOSVersionInfoSize;

        /// <summary>
        /// The major version number of the operating system. For more information, see Remarks.
        /// </summary>
        public uint dwMajorVersion;

        /// <summary>
        /// The minor version number of the operating system. For more information, see Remarks.
        /// </summary>
        public uint dwMinorVersion;

        /// <summary>
        /// The build number of the operating system. This member can be <see cref="VER_PLATFORM_WIN32_NT"/>.
        /// </summary>
        public uint dwBuildNumber;

        /// <summary>
        /// The operating system platform. This member can be the following value.
        /// </summary>
        public PlatformIds dwPlatformId;

        /// <summary>
        /// A null-terminated string, such as "Service Pack 3", that indicates the latest Service Pack installed on the system.
        /// If no Service Pack has been installed, the string is empty.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValArray, ArraySubType = UnmanagedType.U2, SizeConst = 128)]
        public ushort[] szCSDVersion;

        /// <summary>
        /// The major version number of the latest Service Pack installed on the system.
        /// For example, for Service Pack 3, the major version number is 3.
        /// If no Service Pack has been installed, the value is zero.
        /// </summary>
        public ushort wServicePackMajor;

        /// <summary>
        /// The minor version number of the latest Service Pack installed on the system.
        /// For example, for Service Pack 3, the minor version number is 0.
        /// </summary>
        public ushort wServicePackMinor;

        /// <summary>
        /// A bit mask that identifies the product suites available on the system.
        /// This member can be a combination of <see cref="SuiteMasks"/>.
        /// </summary>
        public ushort wSuiteMask;

        /// <summary>
        /// Any additional information about the system.
        /// This member can be one of <see cref="ProductTypes"/>.
        /// </summary>
        public ProductTypes wProductType;

        /// <summary>
        /// Reserved for future use. 
        /// </summary>
        public byte wReserved;
    }
}
