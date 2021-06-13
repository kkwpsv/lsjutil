using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Enums.SystemErrorCodes;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// An <see cref="SP_DRVINFO_DATA"/> structure contains information about a driver.
    /// This structure is a member of a driver information list that can be associated with
    /// a particular device instance or globally with a device information set.
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/setupapi/ns-setupapi-sp_drvinfo_data_v2_w
    /// </para>
    /// </summary>
    /// <remarks>
    /// In SetupAPI.h, this structure equates to either SP_DRVINFO_DATA_V1 or SP_DRVINFO_DATA_V2,
    /// based on whether you include the following line in your source code:
    /// <code>
    /// #define  USE_SP_DRVINFO_DATA_V1 1
    /// </code>
    /// Define this identifier only if your component must run on Windows 98 or Millennium Edition, or on Windows NT.
    /// If your component is run only in Windows 2000 and later versions of Windows, do not define the identifier.
    /// If the identifier is not defined, SP_DRVINFO_DATA_V2 is used.
    /// SP_DRVINFO_DATA_V1 does not contain <see cref="DriverDate"/> and <see cref="DriverVersion"/> members.
    /// SetupDiXxx functions that take an <see cref="SP_DRVINFO_DATA"/> structure as a parameter verify
    /// that the <see cref="cbSize"/> member of the supplied structure is equal to the size, in bytes, of the structure.
    /// If the <see cref="cbSize"/> member is not set correctly for an input parameter,
    /// the function will fail and set an error code of <see cref="ERROR_INVALID_PARAMETER"/>.
    /// If the cbSize member is not set correctly for an output parameter, 
    /// the function will fail and set an error code of <see cref="ERROR_INVALID_USER_BUFFER"/>.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct SP_DRVINFO_DATA
    {
        private const int LINE_LEN = 256;

        /// <summary>
        /// The size, in bytes, of the SP_DRVINFO_DATA structure. For more information, see the Remarks section in this topic.
        /// </summary>
        public DWORD cbSize;

        /// <summary>
        /// The type of driver represented by this structure.
        /// Must be one of the following values:
        /// <see cref="SPDIT_CLASSDRIVER"/> <see cref="SPDIT_COMPATDRIVER"/>
        /// </summary>
        public DWORD DriverType;

        /// <summary>
        /// Reserved. For internal use only.
        /// </summary>
        public ULONG_PTR Reserved;

        /// <summary>
        /// A NULL-terminated string that describes the device supported by this driver.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = LINE_LEN)]
        public string Description;

        /// <summary>
        /// A NULL-terminated string that contains the name of the manufacturer of the device supported by this driver.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = LINE_LEN)]
        public string MfgName;

        /// <summary>
        /// A NULL-terminated string giving the provider of this driver.
        /// This is typically the name of the organization that creates the driver or INF file. ProviderName can be an empty string.
        /// </summary>
        [MarshalAs(UnmanagedType.ByValTStr, SizeConst = LINE_LEN)]
        public string ProviderName;

        /// <summary>
        /// Date of the driver.
        /// From the DriverVer entry in the INF file.
        /// See the INF DDInstall Section for more information about the DriverVer entry.
        /// </summary>
        public FILETIME DriverDate;

        /// <summary>
        /// Version of the driver. From the DriverVer entry in the INF file.
        /// </summary>
        public DWORDLONG DriverVersion;
    }
}
