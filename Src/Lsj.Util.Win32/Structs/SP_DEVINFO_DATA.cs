using Lsj.Util.Win32.BaseTypes;
using System.Runtime.InteropServices;
using static Lsj.Util.Win32.Enums.SystemErrorCodes;

namespace Lsj.Util.Win32.Structs
{
    /// <summary>
    /// <para>
    /// An <see cref="SP_DEVINFO_DATA"/> structure defines a device instance that is a member of a device information set.
    /// </para>
    /// <para>
    /// From: https://docs.microsoft.com/zh-cn/windows/win32/api/setupapi/ns-setupapi-sp_devinfo_data
    /// </para>
    /// </summary>
    /// <remarks>
    /// An <see cref="SP_DEVINFO_DATA"/> structure identifies a device in a device information set.
    /// For example, when Windows sends a <see cref="DIF_INSTALLDEVICE"/> request to a class installer and co-installers,
    /// it includes a handle to a device information set and a pointer to an <see cref="SP_DEVINFO_DATA"/> that specifies the particular device.
    /// In addition to DIF requests, this structure is also used in some SetupDiXxx functions.
    /// SetupDiXxx functions that take an <see cref="SP_DEVINFO_DATA"/> structure as a parameter verify
    /// that the <see cref="cbSize"/> member of the supplied structure is equal to the size, in bytes, of the structure.
    /// If the <see cref="cbSize"/> member is not set correctly for an input parameter,
    /// the function will fail and set an error code of <see cref="ERROR_INVALID_PARAMETER"/>.
    /// If the <see cref="cbSize"/> member is not set correctly for an output parameter,
    /// the function will fail and set an error code of <see cref="ERROR_INVALID_USER_BUFFER"/>.
    /// </remarks>
    [StructLayout(LayoutKind.Sequential, CharSet = CharSet.Unicode)]
    public struct SP_DEVINFO_DATA
    {
        /// <summary>
        /// The size, in bytes, of the <see cref="SP_DEVINFO_DATA"/> structure.
        /// For more information, see the following Remarks section.
        /// </summary>
        public DWORD cbSize;

        /// <summary>
        /// The GUID of the device's setup class.
        /// </summary>
        public GUID ClassGuid;

        /// <summary>
        /// An opaque handle to the device instance (also known as a handle to the devnode).
        /// Some functions, such as SetupDiXxx functions, take the whole <see cref="SP_DEVINFO_DATA"/> structure
        /// as input to identify a device in a device information set.
        /// Other functions, such as CM_Xxx functions like <see cref="CM_Get_DevNode_Status"/>, take this <see cref="DevInst"/> handle as input.
        /// </summary>
        public DWORD DevInst;

        /// <summary>
        /// Reserved.
        /// For internal use only.
        /// </summary>
        public ULONG_PTR Reserved;
    }
}
