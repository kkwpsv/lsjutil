using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Enums.SystemErrorCodes;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// An <see cref="SP_DEVICE_INTERFACE_DATA"/> structure defines a device interface in a device information set.
    /// </para>
    /// <para>
    /// From: <see href="https://learn.microsoft.com/en-us/windows/win32/api/setupapi/ns-setupapi-sp_device_interface_data"/>
    /// </para>
    /// </summary>
    /// <remarks>
    /// A SetupAPI function that takes an instance of the <see cref="SP_DEVICE_INTERFACE_DATA"/> structure as a parameter
    /// verifies whether the <see cref="cbSize"/> member of the supplied structure is equal to the size, in bytes, of the structure.
    /// If the <see cref="cbSize"/> member is not set correctly, the function will fail and set an error code of <see cref="ERROR_INVALID_USER_BUFFER"/>.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct SP_DEVICE_INTERFACE_DATA
    {
        /// <summary>
        /// The size, in bytes, of the <see cref="SP_DEVICE_INTERFACE_DATA"/> structure.
        /// For more information, see the Remarks section.
        /// </summary>
        public DWORD cbSize;

        /// <summary>
        /// The <see cref="GUID"/> for the class to which the device interface belongs.
        /// </summary>
        public GUID InterfaceClassGuid;

        /// <summary>
        /// <para>
        /// Can be one or more of the following:
        /// </para>
        /// <para>
        /// <see cref="SPINT_ACTIVE"/>
        /// </para>
        /// <para>
        /// The interface is active (enabled).
        /// </para>
        /// <para>
        /// <see cref="SPINT_DEFAULT"/>
        /// </para>
        /// <para>
        /// The interface is the default interface for the device class.
        /// </para>
        /// <para>
        /// <see cref="SPINT_REMOVED"/>
        /// </para>
        /// <para>
        /// The interface is removed.
        /// </para>
        /// </summary>
        public DWORD Flags;

        /// <summary>
        /// Reserved.
        /// Do not use.
        /// </summary>
        public ULONG_PTR Reserved;
    }
}
