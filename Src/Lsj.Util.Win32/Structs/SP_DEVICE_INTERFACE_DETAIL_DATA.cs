using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Enums.SystemErrorCodes;
using static Lsj.Util.Win32.Kernel32;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// An <see cref="SP_DEVICE_INTERFACE_DETAIL_DATA"/> structure contains the path for a device interface.
    /// </para>
    /// <para>
    /// <see href="https://learn.microsoft.com/en-us/windows/win32/api/setupapi/ns-setupapi-sp_device_interface_detail_data_w"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// <para>
    /// An <see cref="SP_DEVICE_INTERFACE_DETAIL_DATA"/> structure identifies the path for a device interface in a device information set.
    /// </para>
    /// <para>
    /// SetupDiXxx functions that take an <see cref="SP_DEVICE_INTERFACE_DETAIL_DATA"/> structure
    /// as a parameter verify that the <see cref="cbSize"/> member of the supplied structure is equal to the size, in bytes, of the structure.
    /// If the <see cref="cbSize"/> member is not set correctly for an input parameter,
    /// the function will fail and set an error code of <see cref="ERROR_INVALID_PARAMETER"/>.
    /// If the <see cref="cbSize"/> member is not set correctly for an output parameter,
    /// the function will fail and set an error code of <see cref="ERROR_INVALID_USER_BUFFER"/>.
    /// </para>
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct SP_DEVICE_INTERFACE_DETAIL_DATA
    {
        /// <summary>
        /// The size, in bytes, of the <see cref="SP_DEVICE_INTERFACE_DETAIL_DATA"/> structure.
        /// For more information, see the following Remarks section.
        /// </summary>
        public DWORD cbSize;

        /// <summary>
        /// A NULL-terminated string that contains the device interface path.
        /// This path can be passed to Win32 functions such as <see cref="CreateFile"/>.
        /// </summary>
        public AnySizeArray<WCHAR> DevicePath;
    }
}
