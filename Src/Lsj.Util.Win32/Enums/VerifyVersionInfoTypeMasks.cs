using Lsj.Util.Win32.Structs;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Enums
{
    /// <summary>
    /// <see cref="VerifyVersionInfo"/> type masks
    /// </summary>
    public enum VerifyVersionInfoTypeMasks : uint
    {
        /// <summary>
        /// VER_BUILDNUMBER
        /// </summary>
        VER_BUILDNUMBER = 0x0000004,

        /// <summary>
        /// VER_MAJORVERSION
        /// </summary>
        VER_MAJORVERSION = 0x0000002,

        /// <summary>
        /// VER_MINORVERSION
        /// </summary>
        VER_MINORVERSION = 0x0000001,

        /// <summary>
        /// VER_PLATFORMID
        /// </summary>
        VER_PLATFORMID = 0x0000008,

        /// <summary>
        /// VER_SERVICEPACKMAJOR
        /// </summary>
        VER_SERVICEPACKMAJOR = 0x0000020,

        /// <summary>
        /// VER_SERVICEPACKMINOR
        /// </summary>
        VER_SERVICEPACKMINOR = 0x0000010,

        /// <summary>
        /// VER_SUITENAME
        /// </summary>
        VER_SUITENAME = 0x0000040,

        /// <summary>
        /// VER_PRODUCT_TYPE
        /// </summary>
        VER_PRODUCT_TYPE = 0x0000080,
    }
}
