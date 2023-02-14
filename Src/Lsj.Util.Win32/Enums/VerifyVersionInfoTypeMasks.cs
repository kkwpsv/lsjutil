using Lsj.Util.Win32.Structs;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <para>
    /// <see cref="VerifyVersionInfo"/> Type Masks
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/winbase/nf-winbase-verifyversioninfow"/>
    /// </para>
    /// </summary>
    public enum VerifyVersionInfoTypeMasks : uint
    {
        /// <summary>
        /// <see cref="OSVERSIONINFOEX.dwBuildNumber"/>
        /// </summary>
        VER_BUILDNUMBER = 0x0000004,

        /// <summary>
        /// <see cref="OSVERSIONINFOEX.dwMajorVersion"/>
        /// If you are testing the major version, you must also test the minor version and the service pack major and minor versions.
        /// </summary>
        VER_MAJORVERSION = 0x0000002,

        /// <summary>
        /// <see cref="OSVERSIONINFOEX.dwMinorVersion"/>
        /// </summary>
        VER_MINORVERSION = 0x0000001,

        /// <summary>
        /// <see cref="OSVERSIONINFOEX.dwPlatformId"/>
        /// </summary>
        VER_PLATFORMID = 0x0000008,

        /// <summary>
        /// <see cref="OSVERSIONINFOEX.wServicePackMajor"/>
        /// </summary>
        VER_SERVICEPACKMAJOR = 0x0000020,

        /// <summary>
        /// <see cref="OSVERSIONINFOEX.wServicePackMinor"/>
        /// </summary>
        VER_SERVICEPACKMINOR = 0x0000010,

        /// <summary>
        /// <see cref="OSVERSIONINFOEX.wSuiteMask"/>
        /// </summary>
        VER_SUITENAME = 0x0000040,

        /// <summary>
        /// <see cref="OSVERSIONINFOEX.wProductType"/>
        /// </summary>
        VER_PRODUCT_TYPE = 0x0000080,
    }
}
